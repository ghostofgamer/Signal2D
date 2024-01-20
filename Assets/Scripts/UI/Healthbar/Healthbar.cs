using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Gradient Gradient;
    [SerializeField] private Health _health;

    private Coroutine _changer;
    private float _speed = 60f;

    private void OnEnable()
    {
        _health.HealthChanged += GetValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= GetValue;
    }

    private void Start()
    {
        SetValue();
        ChangeColor();
    }

    private void GetValue(float health)
    {
        if (_changer != null)
            StopCoroutine(_changer);

        _changer = StartCoroutine(ChangeValue(health));
    }

    private IEnumerator ChangeValue(float health)
    {
        while (Slider.value != health)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, health, _speed * Time.deltaTime);
            ChangeColor();
            yield return null;
        }
    }

    private void ChangeColor()
    {
        var speedGradientChanged = Slider.value / 100f;
        Slider.fillRect.GetComponent<Image>().color = Gradient.Evaluate(speedGradientChanged);
    }

    private void SetValue()
    {
        Slider.maxValue = _health.MaxHealth;
        Slider.value = Slider.maxValue;
    }
}