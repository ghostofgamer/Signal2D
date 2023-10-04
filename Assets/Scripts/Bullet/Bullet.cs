using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _flipX = false;

    private readonly float _speed = 15f;

    public float Damage { get; private set; } = 10f;

    private void Update()
    {
        if (_flipX)
        {
            Move(-_speed, _flipX);
        }
        else
            Move(_speed, _flipX);
    }

    public void Init(Transform transform, bool flipX)
    {
        _flipX = flipX;
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }

    private void Move(float speed, bool flag)
    {
        _spriteRenderer.flipX = !flag;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
