using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Misc
{
    public delegate void OnGameEvent<in TArgs>(TArgs args);

    public abstract class GameEvent<TArgs> : ScriptableObject
    {
        private event OnGameEvent<TArgs> listener;
        public event OnGameEvent<TArgs> Listener
        {
            add { listener -= value; listener += value; }
            remove { listener -= value; }
        }

        public void Raise(TArgs args) { listener?.Invoke(args); }
    }
}