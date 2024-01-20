using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Gradient Gradient;

    private Coroutine _changer;
    private float _speed = 60f;

    private void Start()
    {
        SetValue();
        ChangeColor();
    }

    protected void GetValue(float health)
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

    protected abstract void SetValue();
}