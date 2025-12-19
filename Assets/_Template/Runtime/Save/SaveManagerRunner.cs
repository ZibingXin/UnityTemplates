using UnityEngine;

namespace ZXTemplate.Save
{
    public class SaveManagerRunner : MonoBehaviour
    {
        private ISaveManager _manager;

        public void Initialize(ISaveManager manager)
        {
            _manager = manager;
        }

        private void OnApplicationPause(bool paused)
        {
            if (paused) _manager?.SaveAll();
        }

        private void OnApplicationQuit()
        {
            _manager?.SaveAll();
        }

        private void OnDestroy()
        {
            _manager?.SaveAll();
        }
    }
}
