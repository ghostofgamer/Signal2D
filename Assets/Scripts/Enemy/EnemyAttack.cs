using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float _damage = 30f;

    public void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }
}