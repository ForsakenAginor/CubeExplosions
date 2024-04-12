using TMPro;
using UnityEngine;

public class TestSoundSwitcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private VolumeChanger _volumeChanger;

    private bool _isMuted = false;
    private string _disableSound = "Выключить звук";
    private string _enableSound = "Включить звук";


    public void Switch()
    {
        if(_isMuted )
        {
            _text.text = _disableSound;
            _isMuted = false;
            _volumeChanger.UnMute();
        }
        else
        {
            _text.text = _enableSound;
            _isMuted = true;
            _volumeChanger.Mute();
        }
    }
}
