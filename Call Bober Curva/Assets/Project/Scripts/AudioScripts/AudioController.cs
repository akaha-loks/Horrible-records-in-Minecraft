using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audio_;

    private void Start()
    {
        audio_ = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        audio_.volume = PlayerPrefs.GetFloat("volume");
    }
}