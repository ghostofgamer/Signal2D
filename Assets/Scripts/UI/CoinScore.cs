using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _CoinText;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _player.CoinChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coint)
    {
        _CoinText.text = coint.ToString();
    }
}
