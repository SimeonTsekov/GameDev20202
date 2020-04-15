using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public uint health;
    public GameObject DestructionFx;
    public float DestructionFXTimeToLive = 4;
    private GameObject player;

    void Start()
    {
        player = LevelController.Instance.player;
        health = GameStateController.Instance.Level * 10;
    }

    void Update()
    {
        if(health == 0)
        {
            GameObject fx = Instantiate(DestructionFx, transform.position, transform.rotation);
            Destroy(fx, DestructionFXTimeToLive);
            Destroy(gameObject);
            LevelController.Instance.DecreaseBossCount();
        }

        Weapon weapon = GetComponent<Weapon>();
        if (player != null)
        {
            transform.LookAt(player.transform);
        }

        weapon.Shoot(2.0f);
    }
    
    void OnCollisionEnter(Collision coll)
    {
        health--;
    }

    void OnParticleCollision(GameObject damageDealer)
    {
        health--;
    }
}
