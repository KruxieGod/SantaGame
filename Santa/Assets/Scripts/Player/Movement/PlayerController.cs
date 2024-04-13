using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController; // контроллер персонажа, встроенный юнити
    [SerializeField] private AnimatorController _animatorController; // контроллер анимаций
    [SerializeField] private float _speed; // скорость передвижения
    [SerializeField] private float _speedRotation; // скорость поворота
    
    public void MoveTo(Vector3 input)
    {
        _animatorController.Animate(new Vector2(input.x, input.z)); // анимируем движение в зависимости от направления
        if (input == Vector3.zero)
            return;
        Vector3 dir = input;
        dir = new Vector3(dir.x, 0, dir.z);
        dir.Normalize();
        ApplyRotation(dir); // применяем поворот по направлению движения
        _characterController.Move(dir * (_speed * Time.deltaTime)); // двигаем по направлению (Time.deltaTime - разница между кадрами, чтобы персонаж не телепортировался)
    }
    
    private void ApplyRotation(Vector3 direction)
    {
        var eulerAngles = transform.eulerAngles;
        var targetRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, Quaternion.LookRotation(direction).eulerAngles.y, _speedRotation); // вычисляем угол по эйлеру
        var rotation = new Vector3(eulerAngles.x,targetRotation,eulerAngles.z);
        transform.eulerAngles = rotation;
    }
}
