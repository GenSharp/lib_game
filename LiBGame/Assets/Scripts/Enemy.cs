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

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking;
    private bool isDead = false;
    public float attackRange = 3f;
    public float strikeRate = 0.8f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
        if (isDead)
        {
            return;
        }

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            StopMoving();
            AttackPlayer();
        }

        else
        {
            if (agent.isStopped)
            {
                ResumeMoving();
            }

            MoveToPlayer();
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
        isDead = true;
        enemyCounter.EnemyKilled();
        animator.SetBool("Death", true);
        agent.enabled = false;
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private IEnumerator DamageEffect()
    {
        meshRenderer.material.color = damageColor;
        yield return new WaitForSeconds(colorChangeDuration);
        meshRenderer.material.color = originalColor;
    }

    private void MoveToPlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("Running", true);
        animator.SetBool("Attacking", false);
    }

    private void StopMoving()
    {
        agent.isStopped = true;
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", false);
    }

    private void ResumeMoving()
    {
        agent.isStopped = false;
        animator.SetBool("Running", true);
        animator.SetBool("Attacking", false);
    }

    private void AttackPlayer()
    {
        agent.isStopped = true;
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", true);

        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2f);

        if (player != null)
        {
            // Calculate the strike chance
            float strikeChance = Random.value;  // Generate a random value between 0 and 1

            // Check if the strike chance is less than or equal to the desired strike rate
            if (strikeChance <= strikeRate)
            {
                CharacterController playerController = player.GetComponent<CharacterController>();
                if (playerController != null)
                {
                    if (playerController.collisionFlags == CollisionFlags.CollidedSides ||
                        playerController.collisionFlags == CollisionFlags.CollidedAbove ||
                        playerController.collisionFlags == CollisionFlags.CollidedBelow)
                    {
                        HealthManager healthManager = FindObjectOfType<HealthManager>();
                        if (healthManager != null)
                        {
                            healthManager.TakeDamage(10);
                        }
                    }
                }
            }
        }

        isAttacking = false;
    }
}