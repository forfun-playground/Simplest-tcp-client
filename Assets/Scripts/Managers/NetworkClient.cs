using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Events;
using UnityEngine;

namespace Managers
{
    public class NetworkClient : MonoBehaviour
    {
        private TcpClient _client;
        private const int MaxSize = 0x10000;
        private readonly byte[] _bytebuffer = new byte[MaxSize];
        [SerializeField] private OnNetworkConnect onNetworkConnect = default;
        [SerializeField] private OnNetworkConnected onNetworkConnected = default;
        [SerializeField] private OnNetworkConnectedError onNetworkConnectedError = default;
        [SerializeField] private OnNetworkDisconnect onNetworkDisconnect = default;
        [SerializeField] private OnNetworkDisconnected onNetworkDisconnected = default;
        [SerializeField] private OnNetworkDataReceive onNetworkDataReceive = default;
        [SerializeField] private OnNetworkDataSend onNetworkDataSend = default;
        [SerializeField] private string ipAddress = default;
        [SerializeField] private int port = default;

        private void OnEnable()
        {
            onNetworkConnect.Listener += OnConnect;
            onNetworkDisconnect.Listener += OnDisconnect;
            onNetworkDataSend.Listener += OnSend;
        }

        private void OnDisable()
        {
            onNetworkConnect.Listener -= OnConnect;
            onNetworkDisconnect.Listener -= OnDisconnect;
            onNetworkDataSend.Listener -= OnSend;
        }

        private bool IsConnected() { return _client != null && _client.Connected; }

        private void OnConnect(OnNetworkConnect.Args args)
        {
            Connect(args.stateObject);
        }

        public void Connect(System.Object stateObject)
        {
            if (!IsConnected())
            {
                var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                ConnectBegin(endPoint, stateObject);
            }
            else
            {
                Debug.Log("Duplicate connect aborted...");
            }
        }

        private void ConnectBegin(IPEndPoint endPoint, System.Object stateObject)
        {
            try
            {
                _client = new TcpClient();
                var task = _client.ConnectAsync(endPoint.Address, endPoint.Port);
                StartCoroutine(ConnectProcess(task, stateObject));
            }
            catch (Exception e)
            {
                Debug.Log("Socket error: " + e.Message);
            }
        }


        private IEnumerator ConnectProcess(Task task, System.Object stateObject)
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (task.IsCompleted)
                {
                    if (task.IsFaulted)
                    {
                        onNetworkConnectedError.Raise(new OnNetworkConnectedError.Args() { error = task.Exception.GetBaseException().Message });
                        break;
                    }
                    else if (task.IsCanceled)
                    {
                        onNetworkConnectedError.Raise(new OnNetworkConnectedError.Args() { error = "Operation was cancelled" });
                        break;
                    }
                    else
                    {
                        ReceiveBegin(stateObject);
                        break;
                    }
                }
            }
        }

        private void ReceiveBegin(System.Object stateObject)
        {
            _client.NoDelay = true;
            onNetworkConnected.Raise(new OnNetworkConnected.Args() { stateObject = stateObject });
            StartCoroutine(ReceiveLoop());
        }

        private IEnumerator ReceiveLoop()
        {
            while (_client.Connected)
            {
                Receive();
                yield return null;
            }
            onNetworkDisconnected.Raise(new OnNetworkDisconnected.Args());
        }

        private void Receive()
        {
            try
            {
                ReceiveProcess();
            }
            catch (Exception e)
            {
                _client.Close();
                Debug.Log("Socket error: " + e.Message);
            }
        }

        private void ReceiveProcess()
        {
            var stream = _client.GetStream();
            while (stream.DataAvailable)
            {
                var readsize = stream.Read(_bytebuffer, 0, MaxSize);
                var args = new OnNetworkDataReceive.Args { bytearray = new byte[readsize] };
                Array.Copy(_bytebuffer, args.bytearray, readsize);
                onNetworkDataReceive.Raise(args);
            }
        }

        private void OnSend(OnNetworkDataSend.Args args)
        {
            Send(args.bytearray);
        }

        private void Send(byte[] bytearray)
        {
            try
            {
                SendProcess(bytearray);
            }
            catch (Exception e)
            {
                _client.Close();
                Debug.Log("Socket error: " + e.Message);
            }
        }


        private void SendProcess(byte[] bytearray)
        {
            _client.GetStream().Write(bytearray, 0, bytearray.Length);
        }

        private void OnDisconnect(OnNetworkDisconnect.Args args)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (_client.Connected) { _client.Close(); }
        }

    }
}