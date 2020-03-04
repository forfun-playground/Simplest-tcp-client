using UnityEngine;

namespace Misc
{
    public abstract class GameEventAction<TArgs> : MonoBehaviour
    {
        protected abstract GameEvent<TArgs> GameEvent { get; }

        private void OnEnable() { GameEvent.Listener += Action; }

        private void OnDisable() { GameEvent.Listener -= Action; }

        protected abstract void Action(TArgs args);
    }
}