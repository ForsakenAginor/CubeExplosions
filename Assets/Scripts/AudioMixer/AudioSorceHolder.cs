using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioSorceHolder : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float newVolume, float oldValue)
    {
        newVolume = Mathf.Clamp01(newVolume);
        _audioSource.volume = (_audioSource.volume / oldValue) * newVolume;
    }

    public void Mute()
    {
        _audioSource.mute = true;
    }

    public void UnMute()
    {
        _audioSource.mute = false;
    }
}
