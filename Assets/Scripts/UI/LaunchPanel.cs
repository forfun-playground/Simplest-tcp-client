using Events;
using UnityEngine;

namespace UI
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