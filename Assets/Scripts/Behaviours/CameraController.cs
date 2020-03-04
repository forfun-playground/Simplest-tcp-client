using ForFun.Playground.SimpleTcpClient.Events;
using ForFun.Playground.SimpleTcpClient.Meta;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Behaviours
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private OnMetaDataReceive onMetaDataReceive = default;
        [SerializeField] private float smoothTime = 0.5f;
        private Camera _camera;
        private float _velocity;

        private void Start() { _camera = Camera.main; }

        private void OnEnable()
        {
            onMetaDataReceive.Listener += DataProcessingAction;
        }

        private void OnDisable()
        {
            onMetaDataReceive.Listener -= DataProcessingAction;
        }

        private void DataProcessingAction(Metadata metadata)
        {
            if (metadata is Snapshot snapshot)
            {
                SnapshotProcessingAction(snapshot);
            }
        }

        private void SnapshotProcessingAction(Snapshot snapshot)
        {
            var requiredOrthographicSize = snapshot.Radius + 1;
            var currentOrthographicSize = _camera.orthographicSize;
            if (requiredOrthographicSize != currentOrthographicSize)
            {
                var newOrthographicSize = Mathf.SmoothDamp(currentOrthographicSize, requiredOrthographicSize, ref _velocity, smoothTime);
                _camera.orthographicSize = newOrthographicSize;
            }
        }

    }
}