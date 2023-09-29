using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(PlaySoundCoin());
        }
    }

    private IEnumerator PlaySoundCoin()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}