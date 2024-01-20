using UnityEngine;

public class EnemyHealthBar : HealthBar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += GetValue;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= GetValue;
    }

    protected override void SetValue()
    {
        Slider.maxValue = _enemy.MaxHealth;
        Slider.value = Slider.maxValue;
    }
}