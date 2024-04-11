using UnityEngine;

public class MusicVolumeChanger : VolumeChanger
{
    protected override AudioSorceHolder[] FindAudioSourceHolders()
    {
        return FindObjectsByType<MusicAudioSourceHolder>(FindObjectsSortMode.None);
    }
}
