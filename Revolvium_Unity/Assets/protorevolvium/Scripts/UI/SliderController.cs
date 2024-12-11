using GD.Audio;
using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider _slider;
    [Title("Channel")]
    [SerializeField] private AudioMixerGroupName groupName;
    void Start()
    {
        if (GetComponent<Slider>() != null)
            _slider = GetComponent<Slider>();        

        _slider.onValueChanged.RemoveAllListeners();
        _slider.onValueChanged.AddListener((inputValue) =>
        {
            AudioManager.Instance.SetVolume(groupName, inputValue);
        });

        _slider.value = AudioManager.Instance.GetVolume(groupName);
    }
}
