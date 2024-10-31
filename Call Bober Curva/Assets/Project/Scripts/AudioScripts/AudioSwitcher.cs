using UnityEngine;
using UnityEngine.UI;

public class AudioSwitcher : MonoBehaviour
{
    private bool _switcher = true;
    private float _audioVolume = 1;

    [SerializeField] private Sprite _audioOnImage;
    [SerializeField] private Sprite _audioOffImage;
    [SerializeField] private Image _img;

    private void Start()
    {
        if(PlayerPrefs.GetInt("audioTrue") == 0)
            PlayerPrefs.SetFloat("volume", 1);
        else
            _audioVolume = PlayerPrefs.GetFloat("volume");

        if(PlayerPrefs.GetFloat("volume") == 1)
            _img.sprite = _audioOnImage;
        else
            _img.sprite = _audioOffImage;

        PlayerPrefs.SetInt("audioTrue", 1);
    }

    public void AudioSwitch()
    {
        _switcher = !_switcher;
        if(_switcher)
        {
            _audioVolume = 1;
            _img.sprite = _audioOnImage;
        }
        else
        {
            _audioVolume = 0;
            _img.sprite = _audioOffImage;
        }
            
        PlayerPrefs.SetFloat("volume", _audioVolume);
    }
}
