using System;
using TMPro;
using UnityEngine;

public class SoundSwitcher 
{
    private TextMeshProUGUI _text;
    private AudioSource[] _audioSources;

    private bool _isMuted = false;
    private string _disableSound = "Выключить звук";
    private string _enableSound = "Включить звук";

    public SoundSwitcher(TextMeshProUGUI text, AudioSource[] audioSources)
    {
        _text = text != null ? text : throw new ArgumentNullException(nameof(text));
        _audioSources = audioSources != null ? audioSources : throw new ArgumentNullException(nameof(audioSources));

        _audioSources = audioSources;
    }

    public void Switch()
    {
        if (_isMuted)
        {
            _text.text = _disableSound;
            _isMuted = false;
            
            foreach (AudioSource audioSource in _audioSources)
                audioSource.mute = false;
        }
        else
        {
            _text.text = _enableSound;
            _isMuted = true;

            foreach (AudioSource audioSource in _audioSources)
                audioSource.mute = true;
        }
    }
}
