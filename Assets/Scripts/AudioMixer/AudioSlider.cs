using System;
using UnityEngine.UI;

public class AudioSlider
{
    private Slider _slider;
    private AudioMixerHandler _mixerHandler;
    private MixerGroups _group;

    public AudioSlider(Slider slider, AudioMixerHandler mixerHandler, MixerGroups group)
    {
        _slider = slider != null ? slider : throw new ArgumentNullException(nameof(slider));
        _mixerHandler = mixerHandler != null ? mixerHandler : throw new ArgumentNullException(nameof(mixerHandler));
        _group = group;

        _slider.onValueChanged.AddListener(ChangeVolume);
    }
    
    ~AudioSlider()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        _mixerHandler.ChangeVolume(value, _group);
    }
}
