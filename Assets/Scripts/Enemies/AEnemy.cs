using Assets.Lawis.Factory;
using System.Collections;
using UnityEngine;

public abstract class AEnemy : GenericFactorableItem, IMortal
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float distanceOfAttack;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private bool canMove = true;
    [SerializeField] private float damagePoints;

    private GameObject target;

    // ENCAPSULATION
    protected virtual float Health { get => health; set => health = value; }
    protected virtual float Speed { get => speed; set => speed = value; }
    protected virtual float AttackCooldown { get => attackCooldown; set => attackCooldown = value; }
    protected virtual float DistanceOfAttack { get => distanceOfAttack; set => distanceOfAttack = value; }
    protected virtual bool CanAttack { get => canAttack; set => canAttack = value; }
    protected virtual bool CanMove { get => canMove; set => canMove = value; }
    protected virtual float DamagePoints { get => damagePoints; set => damagePoints = value; }
    protected GameObject Target { get => target; private set => target = value; }


    protected virtual void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (GameManager.Instance.IsGameActive)
        {
            float distance = (Target.transform.position - transform.position).magnitude;
            if (distance > DistanceOfAttack && CanMove)
            {
                Move();
            }
            else
            {
                if (CanAttack)
                {
                    Attack();
                }
            }
        }
    }

    protected virtual void Move()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }

    protected virtual void Attack()
    {
        Debug.Log($"{gameObject.name} attacks!");
        DamageTarget();
        StartCoroutine(nameof(AttackDelay));
    }

    // ABSTRACTION
    protected void DamageTarget()
    {
        IDamageable damageable = Target.GetComponent<IDamageable>();
        damageable?.TakeDamage(DamagePoints);
    }

    IEnumerator AttackDelay()
    {
        CanMove = false;
        CanAttack = false;
        yield return new WaitForSeconds(AttackCooldown);
        CanMove = true;
        CanAttack = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsGameActive)
        {
            Die();
            GameManager.Instance.AddPoints(Mathf.FloorToInt(damagePoints));
        }
    }
}
