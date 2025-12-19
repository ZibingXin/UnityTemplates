using System;

namespace ZXTemplate.Settings
{
    public interface ISettingsService
    {
        SettingsData Data { get; }
        event Action OnChanged;

        void MarkDirty();     // 有些设置不是 slider 直接改（比如 keybind）
        void ApplyAll();      // 重新应用所有设置（启动时、切换场景时都可）
        void Save();          // 保存（SaveManager 也会调用）
        void ResetToDefault();
    }
}
