using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string _locomotionAnim = "Locomotion";
    
    
    public void Animate(Vector2 direction)
    {
        _animator.SetFloat(_locomotionAnim ,direction.magnitude);
    }
}