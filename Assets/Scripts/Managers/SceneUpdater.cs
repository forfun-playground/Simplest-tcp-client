using System.Collections.Generic;
using System.Linq;
using Events;
using Factories;
using Meta;
using Misc;
using UnityEngine;

namespace Managers
{
    public class SceneUpdater : MonoBehaviour
    {
        private readonly Dictionary<int, ICharacter> _characters = new Dictionary<int, ICharacter>();
        [SerializeField] private ReferenceInt selfId = default;
        [SerializeField] private ACharacterFactory characterFactory = default;
        [SerializeField] private OnMetaDataReceive onMetaDataReceive = default;
        [SerializeField] private OnNetworkDisconnected onNetworkDisconnected = default;

        private void OnEnable()
        {
            onMetaDataReceive.Listener += DataProcessingAction;
            onNetworkDisconnected.Listener += OnDisconnectAction;
        }

        private void OnDisable()
        {
            onMetaDataReceive.Listener -= DataProcessingAction;
            onNetworkDisconnected.Listener -= OnDisconnectAction;
        }

        private void DataProcessingAction(Metadata metadata)
        {
            if (metadata is EnterWorld enterWorld)
            {
                EnterWorldProcessingAction(enterWorld);
            }
            else if (metadata is Snapshot snapshot)
            {
                SnapshotProcessingAction(snapshot);
            }
        }

        private void EnterWorldProcessingAction(EnterWorld enterWorld)
        {
            selfId.SetValue(enterWorld.Uid);
        }

        private void SnapshotProcessingAction(Snapshot snapshot)
        {
            ResetCharactersState();
            SetNewCharactersState(snapshot.GetAllActors());
            RemoveNotUpdatedCharacters();
        }

        private void ResetCharactersState()
        {
            foreach (var character in _characters)
            {
                character.Value.ResetUpdated();
            }
        }

        private void SetNewCharactersState(List<Snapshot.Actor> metalist)
        {
            foreach (var meta in metalist)
            {
                var character = GetOrCreateCharacter(meta);
                character.AcceptMeta(meta);
            }
        }

        private ICharacter GetOrCreateCharacter(Snapshot.Actor meta)
        {
            var result = _characters.TryGetValue(meta.Uid, out var character);
            if (result && character.IsAcceptMeta(meta))
            {
                return character;
            }
            else if (result)
            {
                _characters.Remove(meta.Uid);
                character.Disponse();
            }
            var instance = characterFactory.Create(meta);
            _characters.Add(instance.GetUid(), instance);
            return instance;
        }

        private void RemoveNotUpdatedCharacters()
        {
            var items = _characters.Where(f => (!f.Value.IsUpdated()));
            foreach (var item in items.ToList())
            {
                _characters.Remove(item.Key);
                item.Value.Disponse();
            }
        }

        private void OnDisconnectAction(OnNetworkDisconnected.Args args)
        {
            foreach (var character in _characters)
            {
                character.Value.Disponse();
            }
            _characters.Clear();
            selfId.SetValue(0);
        }

    }
}