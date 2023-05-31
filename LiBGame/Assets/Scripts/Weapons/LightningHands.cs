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

    public ParticleSystem lightningEffectPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        manaSystem = FindObjectOfType<ManaSystem>();
        lightningCollider.SetActive(false);
        lightningColliderParent = GameObject.Find("RukeCarobnjakaBolje");
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

        GameObject lightningCollider = lightningColliderParent.transform.GetChild(2).gameObject;
        lightningCollider.SetActive(true);

        ParticleSystem lightningEffect = Instantiate(lightningEffectPrefab, lightningCollider.transform.position, Quaternion.identity);
        lightningEffect.Play();

        lightningCollider.transform.position = lightningColliderParent.transform.position + lightningColliderParent.transform.forward * -1f + lightningColliderParent.transform.right * 1f;

        Quaternion desiredRotation = lightningCollider.transform.rotation;
        lightningEffect.transform.rotation = desiredRotation;

        yield return new WaitForSeconds(fireRate);

        lightningEffect.Stop();
        Destroy(lightningEffect.gameObject);

        lightningCollider.SetActive(false);
        canFire = true;
    }
}