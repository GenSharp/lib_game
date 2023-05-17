using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{

    public int damage = 4;
    private float speed = 10f;
    public float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyOrb", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        DestroyOrb();
    }

    void DestroyOrb()
    {
        Destroy(gameObject);
    }
}
