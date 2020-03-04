using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Actors
{
    public class Target : CharacterBase
    {
        public override bool IsAcceptMeta(Snapshot.Actor meta)
        {
            return meta is Snapshot.Target;
        }

        public override void AcceptMeta(Snapshot.Actor meta)
        {
            SetUpdated(true);
            SetActive(meta.Active);
            transform.position = new Vector2(meta.Position.X, meta.Position.Y);
        }
    }
}