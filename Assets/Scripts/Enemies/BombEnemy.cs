using UnityEngine;

// INHERITANCE
public class BombEnemy : AEnemy
{
    // POLYMORPHISM
    protected override void Attack()
    {
        Debug.Log("KABOOOOOOOOM");
        DamageTarget();
        Die();
    }
}
