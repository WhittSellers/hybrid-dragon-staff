using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireSoundBehavior : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool isPlaying = false;
    void OnEnable()
    {
        PerformanceEvents.OnToggleFireSoundsEvent += ToggleFireSounds;
    }

    void OnDisable()
    {
        PerformanceEvents.OnToggleFireSoundsEvent -= ToggleFireSounds;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void ToggleFireSounds()
    {
        if(isPlaying == false)
        {
            _audioSource.Play();
            isPlaying = true;
        }
        else if(isPlaying == true)
        {
            _audioSource.Stop();
            isPlaying = false;
        }
    }
}
