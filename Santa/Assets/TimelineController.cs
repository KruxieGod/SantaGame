using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector; // timeline сам
    [SerializeField] private Animator _animator; // аниматор человека на горке
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
            _playableDirector.Play();// продолжаем timeline
            _animator.speed = 1f; // продолжаем анимацию
        }
        else
        {
            _playableDirector.Pause(); // останавливаем timeline
            _animator.speed = 0f; // останаливаем
        }
    }
}
