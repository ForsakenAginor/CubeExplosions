using UnityEngine;

public class ButtonVolumeChanger : VolumeChanger
{
    protected override AudioSorceHolder[] FindAudioSourceHolders()
    {
        return FindObjectsByType<ButtonAudioSourceHolder>(FindObjectsSortMode.None);
    }
}
