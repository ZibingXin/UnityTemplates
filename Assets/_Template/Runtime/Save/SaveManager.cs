using System.Collections.Generic;

namespace ZXTemplate.Save
{
    public class SaveManager : ISaveManager
    {
        private readonly List<ISaveParticipant> _participants = new();

        public void Register(ISaveParticipant participant)
        {
            if (participant == null) return;
            if (_participants.Contains(participant)) return;
            _participants.Add(participant);
        }

        public void Unregister(ISaveParticipant participant)
        {
            if (participant == null) return;
            _participants.Remove(participant);
        }

        public void SaveAll()
        {
            for (int i = 0; i < _participants.Count; i++)
            {
                _participants[i].Save();
            }
        }
    }
}
