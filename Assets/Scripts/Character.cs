using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth { get; private set; }
    public bool IsDiyng => CurrentHealth <= 0;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
            Die();
    }

    public void Heal(float heal)
    {
        CurrentHealth += heal;
        HealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}