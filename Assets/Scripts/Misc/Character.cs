using ForFun.Playground.SimpleTcpClient.Meta;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Misc
{

    public enum CharacterType { None, Self, Player, NonPlayer }

    public abstract class CharacterBase : MonoBehaviour, ICharacter
    {
        private int _uid;
        private bool _active;
        private bool _updated;

        public int GetUid() { return _uid; }

        public bool IsUpdated() { return _updated; }

        public void SetUpdated(bool updated) { this._updated = updated; }

        public bool IsActive() { return _active; }

        public void SetActive(bool active) { this._active = active; }

        public void ResetUpdated() { _updated = false; }

        public virtual void Construct(int uid) { this._uid = uid; }

        public abstract bool IsAcceptMeta(Snapshot.Actor meta);
        
        public abstract void AcceptMeta(Snapshot.Actor meta);

        public void Disponse() { Destroy(gameObject); }
    }
}