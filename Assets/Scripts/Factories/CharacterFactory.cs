using System;
using ForFun.Playground.SimpleTcpClient.Actors;
using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Factories
{
    [CreateAssetMenu(fileName = "CharacterFactory", menuName = "Factories/CharacterFactory", order = 50)]
    public class CharacterFactory : ACharacterFactory
    {
        [SerializeField] private Agent agentPrefab = default;
        [SerializeField] private Target targetPrefab = default;

        public override ICharacter Create(Snapshot.Actor meta)
        {
            switch (meta)
            {
                case Snapshot.Target _:
                    return CreateTarget(meta);
                case Snapshot.Playable _:
                    return CreateAgent(meta);
                case Snapshot.NonPlayable _:
                    return CreateAgent(meta);
                default:
                    throw new NotSupportedException("No found suitable Actor");
            }
        }

        private ICharacter CreateTarget(Snapshot.Actor meta)
        {
            var position = new Vector2(meta.Position.X, meta.Position.Y);
            var rotation = Quaternion.identity;
            var instance = Instantiate(targetPrefab, position, rotation);
            instance.Construct(meta.Uid);
            return instance;
        }

        private ICharacter CreateAgent(Snapshot.Actor meta)
        {
            var position = new Vector2(meta.Position.X, meta.Position.Y);
            var rotation = Quaternion.identity;
            var instance = Instantiate(agentPrefab, position, rotation);
            instance.Construct(meta.Uid);
            return instance;
        }

    }
}