using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    private MeshRenderer meshRenderer;
    private Color originalColor;
    private Color damageColor = Color.red;
    private float colorChangeDuration = 0.1f;

    private EnemyCounter enemyCounter;

    private Animator animator;
    private Transform target;
    private NavMeshAgent agent;
    public LayerMask isPlayer;
    public float attackRange = 2f;
    public bool playerInAttackRange;
    private bool alreadyAttacked;
    public float timeBetweenAttacks = 2f;
    private float rotationSpeed = 10f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;

        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;

        enemyCounter = FindObjectOfType<EnemyCounter>();
    }

    // Update is called once per frame
    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (playerInAttackRange)
        {
            AttackPlayer();
        }

        else
        {
            ChasePlayer();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine(DamageEffect());
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        enemyCounter.EnemyKilled();
        animator.SetBool("Death", true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private IEnumerator DamageEffect()
    {
        meshRenderer.material.color = damageColor;
        yield return new WaitForSeconds(colorChangeDuration);
        meshRenderer.material.color = originalColor;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            HealthManager healthManager = target.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(10);
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}