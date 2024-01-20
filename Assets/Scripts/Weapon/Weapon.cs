using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootpoint;
    [SerializeField] private Transform _container;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Shoot()
    {
        var bullet = Instantiate(_prefab, _container);
        bullet.Init(_shootpoint, _spriteRenderer.flipX);
    }
}