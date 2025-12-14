using UnityEngine;

public class AudioProbe : MonoBehaviour
{
    public void Dump(string tag)
    {
        var sources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        Debug.Log($"=== AudioProbe {tag} | AudioSources: {sources.Length} ===");
        foreach (var s in sources)
        {
            var clipName = s.clip ? s.clip.name : "(null)";
            var group = s.outputAudioMixerGroup ? s.outputAudioMixerGroup.name : "(no group)";
            Debug.Log($"[{s.gameObject.name}] enabled={s.enabled} active={s.gameObject.activeInHierarchy} " +
                      $"playing={s.isPlaying} clip={clipName} vol={s.volume} mute={s.mute} group={group}");
        }
    }
}
