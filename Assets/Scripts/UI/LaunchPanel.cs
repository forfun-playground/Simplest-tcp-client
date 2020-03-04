using ForFun.Playground.SimpleTcpClient.Events;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.UI
{
    public class LaunchPanel : MonoBehaviour { 

        [SerializeField] private OnNetworkConnected onNetworkConnected = default;
        [SerializeField] private OnNetworkDisconnected onNetworkDisconnected = default;

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

        private void OnConnected(OnNetworkConnected.Args args) { gameObject.SetActive(false); }

        private void OnDisconnected(OnNetworkDisconnected.Args args) { gameObject.SetActive(true); }
    }
}