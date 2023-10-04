using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Player _target;
    [SerializeField] private EnemyAttack _enemyAttack;

    private SpriteRenderer _spriteRenderer;
    private Coroutine _changer;
    private int _currentPosition;
    private float _distance;

    private readonly float _speed = 3f;
    private readonly float _timer = 1f;
    private readonly float _distanceAttack = 1.5f;
    private readonly float _visibilityDistance = 6f;


    private void Start()
    {
        _currentPosition = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Transform targetPosition = _points[_currentPosition];
        _distance = Vector3.Distance(_target.transform.position, transform.position);
        Move(targetPosition);
    }

    private void MoveToTarget(Transform targetPosition)
    {
        _spriteRenderer.flipX = !(targetPosition.position.x > transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
    }

    private void CheckDistanceAttack()
    {
        if (_distance < _distanceAttack && _changer == null)
            _changer = StartCoroutine(CheckDistanceAttack(_target));

        if (_distance > _distanceAttack && _changer != null)
            _changer = null;
        else
            MoveToTarget(_target.transform);
    }

    private void Move(Transform targetPosition)
    {

        if (_distance < _visibilityDistance && _target.gameObject.activeSelf == true)
        {
            CheckDistanceAttack();
        }

        else
        {
            MoveToTarget(targetPosition);

            if (transform.position == targetPosition.position)
            {
                _currentPosition++;

                if (_currentPosition >= _points.Length)
                    _currentPosition = 0;
            }
        }
    }

    private IEnumerator CheckDistanceAttack(Player player)
    {
        var waitForSeconds = new WaitForSeconds(_timer);

        while (_distance < _distanceAttack)
        {
            _enemyAttack.Attack(player);
            yield return waitForSeconds;
        }
    }
}
