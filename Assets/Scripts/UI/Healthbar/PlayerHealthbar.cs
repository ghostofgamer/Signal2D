using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : Healthbar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += GetValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= GetValue;
    }

    protected override void Setvalue()
    {
        Slider.maxValue = _player.MaxHealth;
        Slider.value = Slider.maxValue;
    }
}
