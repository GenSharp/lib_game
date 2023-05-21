using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzureOrbStaff : MonoBehaviour
{
    public float attackInterval = 0.28f;
    private float lastAttackTime = 0f;

    public GameObject orbProjectile;
    public Transform orbSpawnPoint;
    private float orbSpeed = 10f;

    private MouseLook mouseLook;
    private ManaSystem manaSystem;

    // Start is called before the first frame update
    private void Start()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        manaSystem = FindObjectOfType<ManaSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime > attackInterval)
        {
            FireWeapon();
            lastAttackTime = Time.time;
        }
    }

    void FireWeapon()
    {
        if (manaSystem.UseMana(1))
        {
            Quaternion projectileRotation = Quaternion.Euler(mouseLook.GetXRotation(), mouseLook.GetYRotation(), 0f);
            GameObject orb = Instantiate(orbProjectile, orbSpawnPoint.position, projectileRotation);
            Rigidbody orbRigidbody = orb.GetComponent<Rigidbody>();
            orbRigidbody.velocity = orb.transform.forward * orbSpeed;

            lastAttackTime = Time.time;
        }
    }
}