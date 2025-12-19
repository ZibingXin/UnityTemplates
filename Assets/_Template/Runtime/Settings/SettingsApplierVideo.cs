using UnityEngine;

namespace ZXTemplate.Settings
{
    public static class SettingsApplierVideo
    {
        public static void Apply(VideoSettings v)
        {
            v.Clamp();

            // 画质
            if (QualitySettings.names.Length > 0)
                QualitySettings.SetQualityLevel(v.qualityIndex, true);

            // 全屏模式（课程项目用这两种足够）
            var mode = v.fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

            // 分辨率
            Screen.SetResolution(v.width, v.height, mode);
        }
    }
}
