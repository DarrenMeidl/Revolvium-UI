using UnityEngine;
using UnityEngine.Audio;
using GD.Pool;
using GD.Types;
using Sirenix.OdinInspector;
using System.Collections;
using DG.Tweening;
using UnityEditor;

namespace GD.Audio {
    /// <summary>
    /// AudioManager is a Singleton class that manages the audio in the game.
    /// </summary>
    public class AudioManager : Singleton<AudioManager> {
        [Title("AudioSource & Pool")]
        [SerializeField]
        [Tooltip("The prefab used to instantiate AudioSources.")]
        private AudioSource audioSourcePrefab;

        [SerializeField]
        [Tooltip("The initial size of the AudioSource pool.")]
        [Range(1, 32)]
        private int initialPoolSize = 8;

        [Title("Audio Mixer")]
        [SerializeField]
        [Tooltip("The AudioMixer used to control the audio groups.")]
        private AudioMixer audioMixer;

        [Title("Audio Mixer Groups")]
        [SerializeField]
        private AudioMixerGroup masterGroup;

        [SerializeField]
        private AudioMixerGroup ambientGroup;

        [SerializeField]
        private AudioMixerGroup backgroundGroup;

        [SerializeField]
        private AudioMixerGroup sfxGroup;

        [SerializeField]
        private AudioMixerGroup uiGroup;

        [Title("Current Volumes")]
        [SerializeField] private VolumeState volumeLevels;

        private ObjectPool<AudioSource> audioSourcePool;

        protected override void Awake() {
            base.Awake();

            // Initialize the AudioSource pool
            audioSourcePool = new ObjectPool<AudioSource>(audioSourcePrefab,
                initialPoolSize);            
        }

        private void Start()
        {
            foreach (AudioMixerGroupName groupName in AudioMixerGroupName.GetValues(typeof(AudioMixerGroupName)))
            {
                SetVolume(groupName, GetVolume(groupName));
                Debug.Log("Setting volume for " + groupName + " to " + GetVolume(groupName));
            }
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
                AudioMixerGroupName.Master => masterGroup,
                AudioMixerGroupName.Ambient => ambientGroup,
                AudioMixerGroupName.Background => backgroundGroup,
                AudioMixerGroupName.SFX => sfxGroup,
                AudioMixerGroupName.UI => uiGroup,
                _ => null,
            };
        }
        public void SetVolume(AudioMixerGroupName groupName, float volume)
        {
            if (volume < 0 || volume > 1f) // don't allow invalid values
                return;
            else if (volume == 0)
                audioMixer.SetFloat(GetVolumeParameterName(groupName), -80f);
            else
                audioMixer.SetFloat(GetVolumeParameterName(groupName), Mathf.Log10(volume) * 60f);

            switch (groupName)
            {
                case AudioMixerGroupName.Master:
                    volumeLevels.MasterVolume = volume;
                    break;
                case AudioMixerGroupName.Ambient:
                    volumeLevels.AmbientVolume = volume;
                    break;
                case AudioMixerGroupName.Background:
                    volumeLevels.BackgroundVolume = volume;
                    break;
                case AudioMixerGroupName.SFX:
                    volumeLevels.SFXVolume = volume;
                    break;
                case AudioMixerGroupName.UI:
                    volumeLevels.UIVolume = volume;
                    break;
            }
        }
        
        public float GetVolume(AudioMixerGroupName groupName) {
            switch (groupName)
            {
                case AudioMixerGroupName.Master:
                    return volumeLevels.MasterVolume;
                case AudioMixerGroupName.Ambient:
                    return volumeLevels.AmbientVolume;
                case AudioMixerGroupName.Background:
                    return volumeLevels.BackgroundVolume;
                case AudioMixerGroupName.SFX:
                    return volumeLevels.SFXVolume;
                case AudioMixerGroupName.UI:
                    return volumeLevels.UIVolume;
            }
            return 1f; // default value
        }

        private string GetVolumeParameterName(AudioMixerGroupName groupName)
        {
            string name = groupName switch
            {
                AudioMixerGroupName.Master => "volMaster",
                AudioMixerGroupName.Ambient => "volAmbient",
                AudioMixerGroupName.Background => "volBackground",
                AudioMixerGroupName.SFX => "volSFX",
                AudioMixerGroupName.UI => "volUI",
                _ => null,
            };
            return name;
        }
        public void PlaySound(AudioClip clip, AudioMixerGroupName groupName, Vector3 position = default) {
            AudioSource audioSource = audioSourcePool.Get();
            audioSource.transform.position = position;
            audioSource.clip = clip;
            audioSource.outputAudioMixerGroup = GetAudioMixerGroup(groupName);
            audioSource.Play();

            StartCoroutine(ReturnAudioSourceAfterPlaying(audioSource));
        }

        private IEnumerator ReturnAudioSourceAfterPlaying(AudioSource audioSource) {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSourcePool.ReturnToPool(audioSource);
        }
    }
}