using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private Bullet _bullet;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            gameObject.SetActive(false);
            enemy.TakeDamage(_bullet.Damage);
        }
    }
}
