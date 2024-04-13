using System.Collections;
using System.Linq;
using UnityEngine;


public class PathMovement : MonoBehaviour
{
    public Transform[] Paths;
    public PlayerController _player;
    private Coroutine _currentCoroutine;
    private bool _isMoving;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // считываем клавишу G
            MoveToTransitions(); // запускаем метод запуска или отключения передвижения
    }

    private void MoveToTransitions()
    {
        _isMoving = !_isMoving;
        if (!_isMoving)
        {
            _player.MoveTo(Vector3.zero);
            StopCoroutine(_currentCoroutine); // если не джвигаемся , то останавливаем движение
            return;
        }

        _currentCoroutine = StartCoroutine(Move()); // запускаем движение
    }

    private IEnumerator Move()
    {
        var currentPoint = Paths.OrderBy(x => Vector3.Distance( _player.transform.position, x.position)).FirstOrDefault(); // сортируем точки в порядке убывания и берем самую ближную к игроку
        var nextPoint = GetNextPoint(currentPoint); // берем след позицию , относительно текущей позиции
        while (true)
        {
            var distance = Vector3.Distance(nextPoint.position, _player.transform.position);
            Debug.Log("distance: " + distance);
            if (Vector3.Distance(nextPoint.position,_player.transform.position) < 5f) // если дистанция меньше 5, то берем след точку
                nextPoint = GetNextPoint(nextPoint);
            _player.MoveTo((nextPoint.position - _player.transform.position).normalized); // двигаем персонажа 
            yield return null;
        }
    }

    private Transform GetNextPoint(Transform currentPoint)
    {
        for (var i = 0; i < Paths.Length; i++)
            if (Paths[i] == currentPoint)
                return Paths.Length <= i + 1 ? Paths[0] : Paths[i + 1]; // берем след позицию , а если последняя , то первую

        return null;
    }
}