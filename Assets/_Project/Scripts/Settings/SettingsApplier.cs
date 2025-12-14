using UnityEngine;
using ZXTemplate.Audio;
using ZXTemplate.Core;

public static class SettingsApplier
{
    // 这里的参数名要和 AudioMixer 暴露的 Exposed Parameter 完全一致
    public const string MasterParam = "Master";
    public const string BgmParam = "BGM";
    public const string SfxParam = "SFX";

    public static void ApplyAudio(SettingsData data)
    {
        var audio = ServiceContainer.Get<IAudioService>();
        audio.SetMixerVolume(MasterParam, data.master);
        audio.SetMixerVolume(BgmParam, data.bgm);
        audio.SetMixerVolume(SfxParam, data.sfx);

        AudioListener.pause = false;
        AudioListener.volume = 1f;

        if (audio.TryGetMixerDb(MasterParam, out var m))
            Debug.Log($"Mixer {MasterParam} = {m} dB");
        if (audio.TryGetMixerDb(BgmParam, out var b))
            Debug.Log($"Mixer {BgmParam} = {b} dB");
        if (audio.TryGetMixerDb(SfxParam, out var s))
            Debug.Log($"Mixer {SfxParam} = {s} dB");
    }
}
