using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            TakeCoin(coin);
    }

    private void TakeCoin(Coin coin)
    {
        _wallet.AddCoin();
    }
}