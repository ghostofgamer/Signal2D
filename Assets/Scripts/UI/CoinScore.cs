using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.CoinChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coint)
    {
        _coinText.text = coint.ToString();
    }
}