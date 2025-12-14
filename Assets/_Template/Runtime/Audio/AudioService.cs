using UnityEngine;
using UnityEngine.Audio;

namespace ZXTemplate.Audio
{
    public class AudioService : IAudioService
    {
        private readonly AudioMixer _mixer;
        private readonly AudioLibrary _library;

        private readonly GameObject _root;
        private readonly AudioSource _bgm;
        private readonly AudioSource _sfx;

        public AudioService(AudioMixer mixer, AudioLibrary library, AudioMixerGroup bgmGroup, AudioMixerGroup sfxGroup)
        {
            _mixer = mixer;
            _library = library;

            _root = new GameObject("@Audio");
            Object.DontDestroyOnLoad(_root);
            _root.AddComponent<AudioListener>();

            _bgm = _root.AddComponent<AudioSource>();
            _bgm.loop = true;
            _bgm.playOnAwake = false;
            _bgm.outputAudioMixerGroup = bgmGroup;
            _bgm.ignoreListenerPause = true;

            _sfx = _root.AddComponent<AudioSource>();
            _sfx.playOnAwake = false;
            _sfx.outputAudioMixerGroup = sfxGroup;
            _sfx.ignoreListenerPause = true;
        }

        public void PlayBGM(string id)
        {
            var clip = _library.Find(id);
            if (clip == null) return;

            if (_bgm.clip == clip && _bgm.isPlaying) return;

            _bgm.clip = clip;
            _bgm.Play();
        }

        public void StopBGM() => _bgm.Stop();

        public void PlaySFX(string id)
        {
            var clip = _library.Find(id);
            if (clip == null) return;
            _sfx.PlayOneShot(clip);
        }

        public void SetMixerVolume(string exposedParam, float volume01)
        {
            volume01 = Mathf.Clamp01(volume01);

            // standard: 1 -> 0dB, 0.5 -> -6dB, 0.1 -> -20dB
            float db = (volume01 <= 0.0001f) ? -80f : Mathf.Log10(volume01) * 20f;

            if (!_mixer.SetFloat(exposedParam, db))
                Debug.LogWarning($"AudioMixer exposed param not found: {exposedParam}");
        }


        public bool TryGetMixerDb(string exposedParam, out float db)
        {
            return _mixer.GetFloat(exposedParam, out db);
        }

    }
}
