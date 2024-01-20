using System.Collections;
using UnityEngine;

public class FirsAid : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Transform _particlePosition;

    private AudioSource _audioSource;
    private Coroutine _changer;
    private float _heal = 10f;
    private float _waitTime = 0.5f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.GetComponent<Health>().CurrentHealth < player.GetComponent<Health>().MaxHealth)
            {
                if (_changer != null)
                    StopCoroutine(_changer);

                _changer = StartCoroutine(Heal(player));
            }
        }
    }

    private IEnumerator Heal(Player player)
    {
        var waitForSeconds = new WaitForSeconds(_waitTime);
        var particle = Instantiate(_particle, transform);
        particle.gameObject.transform.position = _particlePosition.position;
        _audioSource.Play();
        player.Heal(_heal);
        yield return waitForSeconds;
        gameObject.SetActive(false);
    }
}