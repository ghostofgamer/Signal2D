using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private Coroutine _coroutine;
    private float _howManySeconds = 0.3f;

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
        var waitForSeconds = new WaitForSeconds(_howManySeconds);
        GetComponent<AudioSource>().Play();
        player.AddCoin();
        yield return waitForSeconds;
        gameObject.SetActive(false);
    }
}