using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private VampirismButton _button;
    [SerializeField] private Player _player;

    private Enemy _enemy;
    private bool _isAbility = false;
    private float _currentTime = 0f;
    private float _maxTime = 6f;
    private float _healValue = 0.1f;
    private float _maxDistance = 5f;

    private void Update()
    {
        if (_isAbility)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime < _maxTime)
            {
                float distance = Vector3.Distance(_player.transform.position, _enemy.transform.position);

                if (distance < _maxDistance && _enemy != null)
                    DrinkBlood();
            }
            else
            {
                ResetAbillity();
            }
        }
    }

    public void SetAbillity(Enemy enemy)
    {
        _enemy = enemy;
        _isAbility = true;
    }

    private void DrinkBlood()
    {
        if (!_enemy.IsDiyng)
        {
            _enemy.TakeDamage(_healValue);
            _player.Heal(_healValue);
        }
    }

    private void ResetAbillity()
    {
        _enemy = null;
        _currentTime = 0;
        _button.Reload();
        _isAbility = false;
    }
}