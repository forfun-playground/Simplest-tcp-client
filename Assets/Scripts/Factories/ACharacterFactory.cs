using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Factories
{
    public abstract class ACharacterFactory : ScriptableObject
    {
        public abstract ICharacter Create(Snapshot.Actor meta);

    }
}