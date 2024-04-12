using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    private AudioSorceHolder[] _audioSourceHolders;
    private float _previousVolumeValue = 1;

    private void Start()
    {
        _audioSourceHolders = FindAudioSourceHolders();
    }

    protected virtual AudioSorceHolder[] FindAudioSourceHolders()
    {
        return FindObjectsByType<AudioSorceHolder>(FindObjectsSortMode.None);
    }

    public void ChangeVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        foreach (var source in _audioSourceHolders)
            source.ChangeVolume(volume, _previousVolumeValue);

        _previousVolumeValue = volume;
    }

    public void Mute()
    {
        foreach (var source in _audioSourceHolders)
            source.Mute();
    }

    public void UnMute()
    {
        foreach (var source in _audioSourceHolders)
            source.UnMute();
    }
}
