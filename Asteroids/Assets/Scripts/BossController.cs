using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public uint health;
    public GameObject DestructionFx;
    public float DestructionFXTimeToLive = 4;
    private GameObject player;
    private float dist;
    public float speed = 5.0f;
    private float lastRotatetdTime = 0.0f;
    private float random = 0.0f;

    void Start()
    {
        player = LevelController.Instance.player;
        health = GameStateController.Instance.Level * 10;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        dist = Vector3.Distance(player.transform.position, transform.position);
        
        if (Time.time > lastRotatetdTime + 2)
        {
            lastRotatetdTime = Time.time;
            random = Random.Range(-1, 1);
        }

        if (dist > 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        if (health == 0)
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

        if (GameStateController.Instance.Level % 10 != 0)
        {
            weapon.Shoot(5.0f);
        }
        else
        {
            weapon.Shoot(0.5f);
        }

        float horizontalAxis = random;

        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * speed;
        displacement = transform.rotation * displacement;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + displacement);
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
