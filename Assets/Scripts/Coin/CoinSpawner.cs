using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _countSpawnCoin;
    [SerializeField] private Transform[] _pointSpawn;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CoinsSpawn());
    }

    private IEnumerator CoinsSpawn()
    {
        for (int i = 0; i < _countSpawnCoin; i++)
        {
            Instantiate(_prefab, _pointSpawn[i].position, Quaternion.identity);
            yield return _waitForSeconds;
        }
    }
}
