namespace ZXTemplate.Save
{
    public interface ISaveManager
    {
        void Register(ISaveParticipant participant);
        void Unregister(ISaveParticipant participant);
        void SaveAll();
    }
}
