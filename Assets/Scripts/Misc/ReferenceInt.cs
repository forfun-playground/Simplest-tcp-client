using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Misc
{
    public abstract class ReferenceInt : ScriptableObject
    {
        [SerializeField] private int value;

        public virtual int GetValue() { return this.value; }

        public virtual void SetValue(int value) { this.value = value; }

        public virtual void ChangeValue(int value) { this.value += value; }
    }
}