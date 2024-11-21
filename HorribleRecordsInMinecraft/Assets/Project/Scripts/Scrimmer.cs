using UnityEngine;
using UnityEngine.UI;

public class Scrimmer : MonoBehaviour
{
    [SerializeField] private Sprite[] _scrimSprites;
    private Image _scrimImg;

    [SerializeField] private AudioClip[] _scrimSounds;
    private AudioSource _audioSource;

    private void Awake()
    {
        gameObject.SetActive(false);
        _scrimImg = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActiveScrim()
    {
        RandomSpriteAudio();
        gameObject.SetActive(true);
        Invoke("OffScrim", 1f);
    }

    private void RandomSpriteAudio()
    {
        _audioSource.clip = _scrimSounds[Random.Range(0, _scrimSounds.Length)];
        _scrimImg.sprite = _scrimSprites[Random.Range(0, _scrimSprites.Length)];
    }

    private void OffScrim()
    {
        gameObject.SetActive(false);
    }

    public void RandomActive()
    {
        int i = Random.Range(0, 3);
        if(i == 1)
            ActiveScrim();
    }
}
