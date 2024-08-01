using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMortal
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private int points;

    public float Health { get => health; private set => health = value; }
    public int Points { get => points; private set => points = value; }

    public void Die()
    {
        Debug.Log("GAME OVER");
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damagePoints)
    {
        Debug.Log($"Player takes {damagePoints} of damage");
        Health = Mathf.Clamp(Health - damagePoints, 0, maxHealth);
        if (Health <= 0)
        {
            Die();
        }
    }
}
