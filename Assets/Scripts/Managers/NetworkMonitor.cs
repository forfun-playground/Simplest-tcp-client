using System;
using ForFun.Playground.SimpleTcpClient.Events;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Managers
{
    public class NetworkMonitor : MonoBehaviour
    {
        [SerializeField] private OnNetworkDataSend onNetworkDataSend = default;
        [SerializeField] private OnNetworkDataReceive onNetworkDataReceive = default;
        [SerializeField] private bool enableOnDataSendHexDump = default;
        [SerializeField] private bool enableOnDataReceiveHexDump = default;

        private void OnEnable()
        {
            onNetworkDataSend.Listener += OnDataSend;
            onNetworkDataReceive.Listener += OnDataReceive;
        }

        private void OnDisable()
        {
            onNetworkDataSend.Listener -= OnDataSend;
            onNetworkDataReceive.Listener -= OnDataReceive;
        }

        private void OnDataSend(OnNetworkDataSend.Args args)
        {
            if (enableOnDataSendHexDump)
            {
                var result = ArrayToHexString(args.bytearray);
                Debug.Log("Send: " + result);
            }
        }

        private void OnDataReceive(OnNetworkDataReceive.Args args)
        {
            if (enableOnDataReceiveHexDump)
            {
                var result = ArrayToHexString(args.bytearray);
                Debug.Log("Receive: " + result);
            }
        }

        private static string ArrayToHexString(byte[] bytearray)
        {
            return BitConverter.ToString(bytearray).Replace("-", " ");
        }

    }
}