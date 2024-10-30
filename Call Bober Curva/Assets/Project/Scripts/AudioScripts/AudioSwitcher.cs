using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    private bool _switcher = true;
    private float _audioVolume = 1;

    private void Start()
    {
        if(PlayerPrefs.GetInt("audioTrue") == 0)
            PlayerPrefs.SetFloat("volume", 1);
        else
            _audioVolume = PlayerPrefs.GetFloat("volume");

        PlayerPrefs.SetInt("audioTrue", 1);
    }

    public void AudioSwitch()
    {
        _switcher = !_switcher;
        if(_switcher)
            _audioVolume = 1;
        else
            _audioVolume = 0;

        PlayerPrefs.SetFloat("volume", _audioVolume);
    }
}
