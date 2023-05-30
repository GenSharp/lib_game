using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{

    public Animator animator;
    public Collider swordCollider;
    public int damageAmount = 10;

    private bool canSwing = true;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSwing)
        {
            StartCoroutine(SwingSword());
        }
    }

    private IEnumerator SwingSword()
    {
        canSwing = false;

        animator.SetBool("Swing", true);

        float animationDuration = 0.18f;

        yield return new WaitForSeconds(animationDuration);

        animator.SetBool("Swing", false);

        canSwing = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage(damageAmount);
        }
    }
}