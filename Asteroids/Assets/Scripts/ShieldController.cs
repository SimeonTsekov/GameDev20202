using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public uint health = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            health--;
        }
    }
}
