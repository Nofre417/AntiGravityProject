using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
