using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : Healthbar
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

    protected override void Setvalue()
    {
        Slider.maxValue = _enemy.MaxHealth;
        Slider.value = Slider.maxValue;
    }
}
