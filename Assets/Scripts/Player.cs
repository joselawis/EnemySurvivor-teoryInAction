using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMortal
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public float Health { get => health; private set => health = value; }

    private void Start()
    {
        SceneUiManager.Instance.UpdateHealth(Health);
    }

    public void Die()
    {
        Debug.Log("GAME OVER");
        GameManager.Instance.GameOver();
    }

    public void TakeDamage(float damagePoints)
    {
        Debug.Log($"Player takes {damagePoints} of damage");
        Health = Mathf.Clamp(Health - damagePoints, 0, maxHealth);
        SceneUiManager.Instance.UpdateHealth(Health);
        if (Health <= 0)
        {
            Die();
        }
    }
}
