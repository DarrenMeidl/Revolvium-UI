using UnityEngine;
using UnityEngine.Audio;
using GD.Pool;
using GD.Types;
using Sirenix.OdinInspector;
using System.Collections;
using GD;
using GD.Audio;

/*
 * MUSIC MANAGER - STARTED BY AND WRITTEN BY RUBY
 * BAsed on the audio manager given in class - Found in the GD folder
 */
public class MusicManager : Singleton<MusicManager> {
    [Title("AudioSource & Pool")]
    [SerializeField]
    [Tooltip("The prefab used to instantiate AudioSources.")]
    private AudioSource audioSourcePrefab;

    [SerializeField]
    [Tooltip("The initial size of the AudioSource pool.")]
    [ReadOnly]
    private int initialPoolSize = 3;

    [Title("Audio Mixer")]
    [SerializeField]
    [Tooltip("The AudioMixer used to control the audio groups.")]
    private AudioMixer audioMixer;

    [Title("Audio Mixer Groups")]
    [SerializeField]
    private AudioMixerGroup PlayModeGroup;

    [SerializeField]
    private AudioMixerGroup RotationModeGroup;

    [Title("Current Volumes")]
    [SerializeField] private VolumeState volumeLevels;


    [Title("Play Mode Music")]
    [SerializeField]
    AudioClip PlayModeMusicIntro;
    [SerializeField]
    AudioClip PlayModeMusic;

    [Title("Rotation Mode Music")]
    [SerializeField]
    AudioClip RotationModeMusicIntro;
    [SerializeField]
    AudioClip RotationModeMusic;

    [Title("Ambience")]
    [SerializeField]
    AudioClip AmbienceSFX;

    private ObjectPool<AudioSource> audioSourcePool;

    protected override void Awake() {
        base.Awake();

        // Initialize the AudioSource pool
        audioSourcePool = new ObjectPool<AudioSource>(audioSourcePrefab,
            initialPoolSize);
    }

    public void EnableRotation() {
        SetVolume(AudioMixerGroupName.PlayMode, 0f);
        SetVolume(AudioMixerGroupName.RotationMode, 1f);
    }
    public void DisableRotation() {
        SetVolume(AudioMixerGroupName.PlayMode, 1f);
        SetVolume(AudioMixerGroupName.RotationMode, 0f);
    }

    private void Start() {
        SetVolume(AudioMixerGroupName.PlayMode, 1f);
        SetVolume(AudioMixerGroupName.RotationMode, 0f);
        StartCoroutine(StartSong(PlayModeMusicIntro, PlayModeMusic, AudioMixerGroupName.PlayMode));
        StartCoroutine(StartSong(RotationModeMusicIntro, RotationModeMusic, AudioMixerGroupName.RotationMode));
        StartCoroutine(StartSong(AmbienceSFX, AmbienceSFX, AudioMixerGroupName.Ambient));
    }


    private IEnumerator StartSong(AudioClip songIntro, AudioClip fullSong, AudioMixerGroupName type) {
        AudioManager.Instance.PlaySound(songIntro, type);
        Debug.Log(songIntro.length);
        yield return new WaitForSeconds(songIntro.length);
        PlayMusic(fullSong, type);
    }

    /// <summary>
    /// Gets the AudioMixerGroup associated with the given AudioMixerGroupName.
    /// </summary>
    /// <param name="groupName">The AudioMixerGroupName enum value.</param>
    /// <returns>The corresponding AudioMixerGroup.</returns>
    public AudioMixerGroup GetAudioMixerGroup(AudioMixerGroupName groupName) {
        // Expression based switch from C# 8.0
        // https://www.c-sharpcorner.com/article/c-sharp-8-0-new-feature-swtich-expression/
        return groupName switch {
            AudioMixerGroupName.PlayMode => PlayModeGroup,
            AudioMixerGroupName.RotationMode => RotationModeGroup,
            _ => null,
        };
    }
    public void SetVolume(AudioMixerGroupName groupName, float volume) {
        if (volume < 0 || volume > 1f) // don't allow invalid values
            return;
        else if (volume == 0)
            audioMixer.SetFloat(GetVolumeParameterName(groupName), -80f);
        else
            audioMixer.SetFloat(GetVolumeParameterName(groupName), Mathf.Log10(volume) * 60f);

        switch (groupName) {
            case AudioMixerGroupName.PlayMode:
                volumeLevels.PlayMode = volume;
                break;
            case AudioMixerGroupName.RotationMode:
                volumeLevels.RotationMode = volume;
                break;
        }
    }

    public float GetVolume(AudioMixerGroupName groupName) {
        switch (groupName) {
            case AudioMixerGroupName.PlayMode:
                return volumeLevels.PlayMode;
            case AudioMixerGroupName.RotationMode:
                return volumeLevels.RotationMode;
        }
        return 1f; // default value
    }

    private string GetVolumeParameterName(AudioMixerGroupName groupName) {
        string name = groupName switch {
            AudioMixerGroupName.PlayMode => "volPlayMode",
            AudioMixerGroupName.RotationMode => "volRotationMode",
            _ => null,
        };
        return name;
    }
    public void PlayMusic(AudioClip clip, AudioMixerGroupName groupName = AudioMixerGroupName.Background, Vector3 position = default) {
        AudioSource audioSource = audioSourcePool.Get();
        audioSource.transform.position = position;
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = GetAudioMixerGroup(groupName);
        audioSource.Play();

    }

}
