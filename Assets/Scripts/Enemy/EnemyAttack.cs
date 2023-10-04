using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private readonly float _damage = 30f;

    public void Attack(Player player)
    {
        player.TakeDamage(_damage);
        player.ParticlePlay();
    }
}
