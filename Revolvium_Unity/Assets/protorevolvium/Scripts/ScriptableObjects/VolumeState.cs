using UnityEngine;
[CreateAssetMenu(fileName = "VolumeLevels",
            menuName = "RUB/audio/VolumeLevels")]
public class VolumeState : ScriptableObject
{
    [SerializeField] public float MasterVolume = 1.0f;
    [SerializeField] public float AmbientVolume = 1.0f;
    [SerializeField] public float BackgroundVolume = 1.0f;
    [SerializeField] public float SFXVolume = 1.0f;
    [SerializeField] public float UIVolume = 1.0f;
    [SerializeField] public float PlayMode = 1.0f;
    [SerializeField] public float RotationMode = 1.0f;
}