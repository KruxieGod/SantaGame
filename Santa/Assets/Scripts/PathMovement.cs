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
        if (Input.GetKeyDown(KeyCode.G))
            MoveToTransitions();
    }

    private void MoveToTransitions()
    {
        _isMoving = !_isMoving;
        if (!_isMoving)
        {
            _player.MoveTo(Vector3.zero);
            StopCoroutine(_currentCoroutine);
            return;
        }

        _currentCoroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        var currentPoint = Paths.OrderBy(x => Vector3.Distance( _player.transform.position, x.position)).FirstOrDefault();
        var nextPoint = GetNextPoint(currentPoint);
        while (true)
        {
            var distance = Vector3.Distance(nextPoint.position, _player.transform.position);
            Debug.Log("distance: " + distance);
            if (Vector3.Distance(nextPoint.position,_player.transform.position) < 5f)
                nextPoint = GetNextPoint(nextPoint);
            _player.MoveTo((nextPoint.position - _player.transform.position).normalized);
            yield return null;
        }
    }

    private Transform GetNextPoint(Transform currentPoint)
    {
        for (var i = 0; i < Paths.Length; i++)
            if (Paths[i] == currentPoint)
                return Paths.Length <= i + 1 ? Paths[0] : Paths[i + 1];

        return null;
    }
}