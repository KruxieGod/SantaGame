using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    void Update()
    {
        //var direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        //Move(direction);
    }
    
    public void MoveTo(Vector3 input)
    {
        _animatorController.Animate(new Vector2(input.x, input.z));
        if (input == Vector3.zero)
            return;
        Vector3 dir = input;
        dir = new Vector3(dir.x, 0, dir.z);
        dir.Normalize();
        ApplyRotation(dir);
        _characterController.Move(dir * (_speed * Time.deltaTime));
    }

    private void Move(Vector2 input)
    {
        _animatorController.Animate(input);
        if (input == Vector2.zero)
            return;
        Vector3 dir =  _camera.transform.right*input.x + _camera.transform.forward*input.y;
        dir = new Vector3(dir.x, 0, dir.z);
        dir.Normalize();
        ApplyRotation(dir);
        _characterController.Move(dir * (_speed * Time.deltaTime));
    }
    
    private void ApplyRotation(Vector3 direction)
    {
        var eulerAngles = transform.eulerAngles;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        var targetRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, Quaternion.LookRotation(direction).eulerAngles.y, _speedRotation);
        var rotation = new Vector3(eulerAngles.x,targetRotation,eulerAngles.z);
        transform.eulerAngles = rotation;
    }
}
