using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private int _currentPosition;
    private float _speed = 3f;

    private void Start()
    {
        _currentPosition = 0;
    }

    private void Update()
    {
        Transform targetPosition = _points[_currentPosition];
        GetComponent<SpriteRenderer>().flipX = !(targetPosition.position.x > transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);

        if (transform.position == targetPosition.position)
        {
            _currentPosition++;

            if (_currentPosition >= _points.Length)
                _currentPosition = 0;
        }
    }
}
