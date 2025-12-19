using System;
using ZXTemplate.Save;

namespace ZXTemplate.Settings
{
    public class SettingsService : ISettingsService, ISaveParticipant
    {
        public SettingsData Data { get; private set; }
        public event Action OnChanged;

        private readonly ISaveService _save;
        private bool _dirty;

        public SettingsService(ISaveService save)
        {
            _save = save;
            LoadOrCreate();
            ApplyAll();
            _dirty = false;
        }

        private void LoadOrCreate()
        {
            if (!_save.TryLoad(SettingsKeys.Main, out SettingsData data) || data == null || !data.initialized)
            {
                Data = new SettingsData();
                _save.Save(SettingsKeys.Main, Data);
                return;
            }

            // Migration hook
            if (data.version != SettingsData.CurrentVersion)
            {
                // TODO: future migrations
                data.version = SettingsData.CurrentVersion;
            }

            data.Clamp();
            Data = data;
        }

        public void MarkDirty()
        {
            _dirty = true;
            OnChanged?.Invoke();
        }

        public void ApplyAll()
        {
            Data.Clamp();

            SettingsApplierAudio.Apply(Data.audio);
            SettingsApplierVideo.Apply(Data.video);
            // language/controls: 你加模块时补上
        }

        public void Save()
        {
            if (!_dirty) return;
            Data.Clamp();
            _save.Save(SettingsKeys.Main, Data);
            _dirty = false;
        }

        public void ResetToDefault()
        {
            Data = new SettingsData();
            _save.Save(SettingsKeys.Main, Data);
            ApplyAll();
            OnChanged?.Invoke();
        }
    }
}
