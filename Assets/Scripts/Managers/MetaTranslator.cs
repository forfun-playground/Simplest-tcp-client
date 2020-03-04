using System.Collections;
using Events;
using Handlers;
using Meta;
using Pipeline;
using UnityEngine;

namespace Managers
{
    public class MetaTranslator : MonoBehaviour
    {
        [SerializeField] private OnNetworkConnected onNetworkConnected = default;
        [SerializeField] private OnMetaDataReceive onMetaDataReceive = default;
        [SerializeField] private OnNetworkDataReceive onNetworkDataReceive = default;
        private IInboundTemplate<Metadata> _inboundTemplate = default;
        [SerializeField] private OnMetaDataSend onMetaDataSend = default;
        [SerializeField] private OnNetworkDataSend onNetworkDataSend = default;
        private IOutboundTemplate<Metadata> _outboundTemplate = default;

        private void OnEnable()
        {
            onNetworkConnected.Listener += AcceptConnection;
            onNetworkDataReceive.Listener += InboundTranslate;
            onMetaDataSend.Listener += OutboundTranslate;
        }

        private void OnDisable()
        {
            onNetworkConnected.Listener -= AcceptConnection;
            onNetworkDataReceive.Listener -= InboundTranslate;
            onMetaDataSend.Listener -= OutboundTranslate;
        }

        private void AcceptConnection(OnNetworkConnected.Args args)
        {
            var stateObject = args.stateObject as ChannelState;
            _inboundTemplate = stateObject?.InboundTemplate;
            _outboundTemplate = stateObject?.OutboundTemplate;
            var channelPacktype = stateObject?.ChannelPacktype;
            var bytearray = channelPacktype?.SizedBinaryRepresent();
            StartCoroutine(ConnectionPacktypeSelectMessage(bytearray));
        }

        private IEnumerator ConnectionPacktypeSelectMessage(byte[] bytearray)
        {
            yield return null;
            onNetworkDataSend.Raise(new OnNetworkDataSend.Args() { bytearray = bytearray });
        }

        private void InboundTranslate(OnNetworkDataReceive.Args args)
        {
            var metadata = _inboundTemplate.Translate(args.bytearray);
            foreach (var meta in metadata) { onMetaDataReceive.Raise(meta); }
        }

        private void OutboundTranslate(Metadata metadata)
        {
            byte[] bytearray = _outboundTemplate.Translate(metadata);
            var args = new OnNetworkDataSend.Args() { bytearray = bytearray };
            onNetworkDataSend.Raise(args);
        }
    }
}