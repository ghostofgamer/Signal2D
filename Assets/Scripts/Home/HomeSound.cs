using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HomeSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _targetVolume;
    private Coroutine _coroutine;

    private readonly float _speed = 0.5f;

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    public void OnAlarm()
    {
        _targetVolume = 1f;
        _audioSource.Play();
        PlayCoroutine(_targetVolume);
    }

    public void OffAlarm()
    {
        _targetVolume = 0f;
        PlayCoroutine(_targetVolume);
    }

    private void PlayCoroutine(float target )
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(target));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
