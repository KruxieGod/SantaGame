using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private Animator _animator;
    private bool _isActivated = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            OnPauseTimeline();
    }

    private void OnPauseTimeline()
    {
        _isActivated = !_isActivated;
        if (_isActivated)
        {
            _playableDirector.Play();
            _animator.speed = 1f;
        }
        else
        {
            _playableDirector.Pause();
            _animator.speed = 0f;
        }
    }
}
