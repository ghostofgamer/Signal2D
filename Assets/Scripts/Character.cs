using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected Health Health;

    public bool IsDiyng => Health.CurrentHealth <= 0;

    public void TakeDamage(float damage)
    {
        Health.Decrease(damage);
    }
}