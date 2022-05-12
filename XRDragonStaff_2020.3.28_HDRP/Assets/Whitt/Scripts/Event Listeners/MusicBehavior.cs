using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehavior : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _Playing = false;
    void OnEnable()
    {
        PerformanceEvents.OnToggleMusicEvent += ToggleMusic;
    }

    void OnDisable()
    {
        PerformanceEvents.OnToggleMusicEvent -= ToggleMusic;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void ToggleMusic()
    {
        if(_Playing == false)
        {
            _audioSource.Play();
            _Playing = true;
        }
        else if (_Playing == true)
        {
            _audioSource.Stop();
            _Playing = false;
        }
    }
}
