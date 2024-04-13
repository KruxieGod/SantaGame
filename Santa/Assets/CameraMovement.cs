using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _camera;
    [SerializeField] private float _speed;
    void Start()
    {
        _camera = Camera.main.transform; // выбираем камеру из сцены
    }
    
    void Update()
    {
        Move(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.E) ? 1 :0)); // двигаем в зависимости от нажатых кнопок
    }

    private void Move(Vector3 input)
    {
        if (input == Vector3.zero)
            return;
        Vector3 dir =  _camera.transform.right*input.x + _camera.transform.forward*input.y + _camera.transform.up*input.z; // вычисление направления от нажатых кнопок
        dir = new Vector3(dir.x, dir.y, dir.z);
        dir.Normalize();
        transform.Translate(dir * (_speed * Time.deltaTime)); // плавное перемещение камеры
    }
}
