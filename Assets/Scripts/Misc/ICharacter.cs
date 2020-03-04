using ForFun.Playground.SimpleTcpClient.Meta;

namespace ForFun.Playground.SimpleTcpClient.Misc
{
    public interface ICharacter
    {
        int GetUid();
        bool IsUpdated();
        void SetUpdated(bool updated);
        bool IsActive();
        void SetActive(bool active);
        void ResetUpdated();
        void Construct(int uid);
        bool IsAcceptMeta(Snapshot.Actor meta);
        void AcceptMeta(Snapshot.Actor meta);
        void Disponse();
    }
}