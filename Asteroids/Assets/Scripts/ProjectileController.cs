using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float ProjectileVelocity = 2.5f;
    public float TimeToLive = 5;
    GameObject[] objs;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * ProjectileVelocity;
        Destroy(gameObject, TimeToLive);
    }

    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in objs)
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), projectile.GetComponent<Collider>());
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
