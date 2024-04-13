using System;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string _locomotionAnim = "Locomotion";
    private const string _runningAnim = "Running";
    private const string _idleAnim = "Idle";
    private const string _slideAnim = "Slide";


    public void Animate(Vector2 direction)
    {
        _animator.SetFloat(_locomotionAnim ,direction.magnitude);
    }

    public void Run() {
        _animator.CrossFade(_runningAnim,0.2f);
    }
    public void Idle(){
        _animator.CrossFade(_idleAnim ,0.2f);
    }
    public void Slide() => _animator.CrossFade(_slideAnim,0.2f);
    
}