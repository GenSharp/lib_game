using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHands : MonoBehaviour
{

    public GameObject lightningCollider;
    public Transform playerTransform;
    public float fireRate = 0.5f;
    public int manaCost = 10;

    private bool canFire = true;
    private ManaSystem manaSystem;
    private GameObject lightningColliderParent;

    // Start is called before the first frame update
    private void Start()
    {
        manaSystem = FindObjectOfType<ManaSystem>();
        lightningCollider.SetActive(false);
        lightningColliderParent = GameObject.Find("Hands");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire && manaSystem.currentMana >= manaCost)
        {
            StartCoroutine(FireLightning());
        }
    }

    private IEnumerator FireLightning()
    {
        canFire = false;
        manaSystem.UseMana(manaCost);

        GameObject lightningCollider = lightningColliderParent.transform.GetChild(0).gameObject;
        lightningCollider.SetActive(true);

        lightningCollider.transform.position = lightningColliderParent.transform.position;
        lightningCollider.transform.rotation = lightningColliderParent.transform.rotation;

        yield return new WaitForSeconds(fireRate);

        lightningCollider.SetActive(false);
        canFire = true;
    }
}