using ForFun.Playground.SimpleTcpClient.Events;
using ForFun.Playground.SimpleTcpClient.Meta;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Managers
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private OnNetworkConnected onNetworkConnected = default;
        [SerializeField] private OnNetworkDisconnected onNetworkDisconnected = default;
        [SerializeField] private OnMetaDataSend onMetaDataSend = default;
        private bool _isActive;

        private void OnEnable()
        {
            onNetworkConnected.Listener += OnConnected;
            onNetworkDisconnected.Listener += OnDisconnected;
        }

        private void OnDisable()
        {
            onNetworkConnected.Listener -= OnConnected;
            onNetworkDisconnected.Listener -= OnDisconnected;
        }

        private void OnConnected(OnNetworkConnected.Args args) { _isActive = true; }

        private void OnDisconnected(OnNetworkDisconnected.Args args) { _isActive = false; }

        private void Update()
        {
            if (_isActive && Input.GetButtonDown("Fire1"))
            {
                var posotion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var metadata = new TargetPosition()
                {
                    Position = new Metadata.Vector()
                    {
                        X = posotion.x,
                        Y = posotion.y
                    }
                };
                onMetaDataSend.Raise(metadata);

            }
        }
    }
}