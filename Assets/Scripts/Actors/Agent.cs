using Meta;
using Misc;
using UnityEngine;

namespace Actors
{
    public class Agent : CharacterBase, ICharacter
    {
        [SerializeField] private ReferenceInt selfId = default;
        [SerializeField] private GameObject self = default;
        [SerializeField] private GameObject player = default;
        [SerializeField] private GameObject nonplayer = default;
        private int _targetId;
        private CharacterType _type;
        private Rigidbody2D _rb2;

        private void Awake()
        {
            _rb2 = gameObject.GetComponent<Rigidbody2D>();
        }

        public override void Construct(int uid)
        {
            base.Construct(uid);
            DisableAvatarType();
        }

        public override bool IsAcceptMeta(Snapshot.Actor meta)
        {
            return meta is Snapshot.Agent;
        }

        public override void AcceptMeta(Snapshot.Actor meta)
        {
            var agent = (Snapshot.Agent)meta;
            SetUpdated(true);
            SetActive(agent.Active);
            SetCharacterType(agent);
            this._targetId = agent.Tid;
            transform.position = new Vector2(agent.Position.X, agent.Position.Y);
            _rb2.velocity = new Vector2(agent.Velocity.X, agent.Velocity.Y);
        }

        private void SetCharacterType(Snapshot.Agent agent)
        {
            var type = agent is Snapshot.Playable ?  agent.Uid == selfId.GetValue() ? CharacterType.Self : CharacterType.Player : CharacterType.NonPlayer;
            if (type == this._type) { return; }
            DisableAvatarType();
            switch (type)
            {
                case CharacterType.Self:
                    self.SetActive(true);
                    break;
                case CharacterType.Player:
                    player.SetActive(true);
                    break;
                case CharacterType.NonPlayer:
                    nonplayer.SetActive(true);
                    break;
            }
            this._type = type;
        }

        private void DisableAvatarType()
        {
            this._type = CharacterType.None;
            self.SetActive(false);
            player.SetActive(false);
            nonplayer.SetActive(false);
        }
    }
}