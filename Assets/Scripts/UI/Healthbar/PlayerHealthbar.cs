using UnityEngine;

public class PlayerHealthBar : HealthBar
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

    protected override void SetValue()
    {
        Slider.maxValue = _player.MaxHealth;
        Slider.value = Slider.maxValue;
    }
}