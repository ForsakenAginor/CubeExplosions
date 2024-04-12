using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [Header("AudioSliders")]
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _buttonEffectsVolumeSlider;

    [SerializeField] private Button[] _audioEffectButtons;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _audioControlButton;

    private void Awake()
    {
        AudioMixerHandler mixerHandler = new(_audioMixer);
        AudioSlider masterAudioSlider = new(_masterVolumeSlider, mixerHandler, MixerGroups.MasterVolume);
        AudioSlider musicAudioSlider = new(_musicVolumeSlider, mixerHandler, MixerGroups.MusicVolume);
        AudioSlider buttonEffectsSlider = new(_buttonEffectsVolumeSlider, mixerHandler, MixerGroups.ButtonEffectsVolume);

        foreach (var button in _audioEffectButtons)
        {
            AudioSource audioSource = button.GetComponent<AudioSource>();
            button.onClick.AddListener(audioSource.Play);
        }

        TextMeshProUGUI audioSwitcherLabel = _audioControlButton.GetComponentInChildren<TextMeshProUGUI>();
        AudioSource[] audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        SoundSwitcher soundSwitcher = new(audioSwitcherLabel, audioSources);
        _audioControlButton.onClick.AddListener(soundSwitcher.Switch);
    }

    private void OnDestroy()
    {
        foreach (var button in _audioEffectButtons)        
            button.onClick.RemoveAllListeners();

        _audioControlButton.onClick.RemoveAllListeners();
    }
}
