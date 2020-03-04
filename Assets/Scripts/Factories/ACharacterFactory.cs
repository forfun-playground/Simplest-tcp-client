using Meta;
using Misc;
using UnityEngine;

namespace Factories
{
    public abstract class ACharacterFactory : ScriptableObject
    {
        public abstract ICharacter Create(Snapshot.Actor meta);

    }
}