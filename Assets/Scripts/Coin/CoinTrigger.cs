using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(PlaySoundCoin(player));
        }
    }

    private IEnumerator PlaySoundCoin(Player player)
    {
        GetComponent<AudioSource>().Play();
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}