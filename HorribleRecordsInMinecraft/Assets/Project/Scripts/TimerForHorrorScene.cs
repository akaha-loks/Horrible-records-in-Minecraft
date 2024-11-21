using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerForHorrorScene : MonoBehaviour
{
    private float _timer;
    [SerializeField] private Text _timerText;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private GameObject[] _horrorElements;
    private bool _isMovingStarted = false;

    [SerializeField] private Scrimmer _scrim;
    private bool _scrimStarted;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _horrorSounds;
    private bool _horrorSoundStarted = false;

    [SerializeField] private AudioSource _backgroundMusic;

    [SerializeField] private AudioSource[] _allMusics;

    [SerializeField] private Image _backgroundImage;

    [SerializeField] private GameObject[] _contacts;

    [SerializeField] private GameObject _glitchImage;
    private bool _gitchingStarted = false;

    private void Update()
    {
        if (_timer <= 180)
        {
            _timer += Time.deltaTime;

            if(_timer >= 15 && !_horrorSoundStarted)
            {
                _horrorSoundStarted = true;
                StartCoroutine(HorrorSound());
            }
                
            if(_timer >= 34 && !_isMovingStarted)
            {
                _horrorElements[0].SetActive(true);
                StartCoroutine(TextMoving());
                _isMovingStarted = true;
            }

            if(_timer >= 48)
            {
                _backgroundMusic.pitch = 0.6f;
            }

            if(_timer >= 59 && !_scrimStarted)
            {
                _scrim.ActiveScrim();
                _scrimStarted = true;
                for(int i = 0; i <= _contacts.Length - 1; i++)
                {
                    _allMusics[i].pitch = 0.6f;
                }
            }

            if(_timer >= 70)
            {
                _backgroundImage.color = new Color(1f, 0f, 0f, 1f);
            }

            if(_timer >= 94 && !_gitchingStarted)
            {
                _scrim.ActiveScrim();
                _glitchImage.SetActive(true);
                StartCoroutine(Glitching());
                _gitchingStarted = true;
            }

            if(_timer >= 125)
            {
                for(int i = 0; i <= _contacts.Length - 1; i++)
                {
                    _contacts[i].SetActive(false);
                }
            }

            if(_timer > 140)
            {
                _scrim.ActiveScrim();
            }
        }
        else
        {
            _sceneChanger.SceneLoad("Horror");
        }
        _timerText.text = $"{_timer.ToString("F2")} / 180";
    }

    private IEnumerator TextMoving()
    {
        while (true)
        {
            _horrorElements[0].transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 0);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator HorrorSound()
    {
        while (true)
        {
            PlayRandomHorrorSound();
            yield return new WaitForSeconds(11f);
        }
    }

    private IEnumerator Glitching()
    {
        while (true)
        {
            _glitchImage.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void PlayRandomHorrorSound()
    {
        int randomIndex = Random.Range(0, _horrorSounds.Length);
        _audioSource.clip = _horrorSounds[randomIndex];
        _audioSource.Play();
    }
}
