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

    public Transform cameraLOL;

    private ManaSystem manaSystem;

    // Start is called before the first frame update
    private void Start()
    {
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
        if (FindObjectOfType<ManaSystem>().UseMana(1))
        {
            if (Physics.Raycast(cameraLOL.transform.position, cameraLOL.transform.forward, out RaycastHit hit, 30f))
            {
                orbSpawnPoint.LookAt(hit.point);
            }

            else
            {
                Vector3 newTargetPos = cameraLOL.transform.position + (cameraLOL.transform.forward * 30f);
                newTargetPos.y -= 0.2f;
                orbSpawnPoint.LookAt(newTargetPos);
            }

            GameObject orb = Instantiate(orbProjectile, orbSpawnPoint.position, orbSpawnPoint.rotation);
            orb.GetComponent<Rigidbody>().velocity = orb.transform.forward * orbSpeed;

            lastAttackTime = Time.time;
        }
    }
}