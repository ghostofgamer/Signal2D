using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Transform _positionBlood;

    private int _coin;

    public event UnityAction<int> CoinChanged;

    public void ParticlePlay()
    {
        var blood = Instantiate(_particle, transform);
        blood.transform.position = _positionBlood.position;
    }

    public void AddCoin()
    {
        _coin++;
        CoinChanged?.Invoke(_coin);
    }
}
