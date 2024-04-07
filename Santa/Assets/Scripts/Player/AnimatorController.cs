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
        _animator.CrossFade(_locomotionAnim,0.2f);
        _animator.SetFloat(_locomotionAnim, 1);
    }
    public void Idle(){
        _animator.CrossFade(_locomotionAnim,0.2f);
        _animator.SetFloat(_locomotionAnim, 0);
    }
    public void Slide() => _animator.CrossFade(_slideAnim,0.2f);
    
}