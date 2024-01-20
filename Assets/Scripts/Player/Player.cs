using UnityEngine;

public class Player : Character
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Transform _positionBlood;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        ParticlePlay();
    }

    public void ParticlePlay()
    {
        var blood = Instantiate(_particle, transform);
        blood.transform.position = _positionBlood.position;
    }
}