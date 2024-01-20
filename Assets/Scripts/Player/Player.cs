using UnityEngine;

public class Player : Character
{
    public void Heal(float heal)
    {
        Health.Increase(heal);
    }
}