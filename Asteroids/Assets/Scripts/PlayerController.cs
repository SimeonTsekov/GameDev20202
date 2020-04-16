using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    public float DistanceTreshold = 0.15f;
    public GameObject shieldMk1;
    public int shieldHealth = 0;
    public bool shieldExisting;
    public GameObject blastwaveMk1;
    public AudioClip blastwave;
    public GameObject DestructionFx;
    public float DestructionFXTimeToLive = 4;

    private void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(gameObject);

        if (GameStateController.Instance.shieldUpgrades[2])
        {
            shieldMk1 = Instantiate(shieldMk1, transform.position, transform.rotation);
            shieldMk1.transform.parent = transform;
            shieldHealth = 3;
            AbilitiesController.Instance.SetShieldHealth(shieldHealth);
            shieldExisting = true;
        }
        else if (GameStateController.Instance.shieldUpgrades[1])
        {
            shieldMk1 = Instantiate(shieldMk1, transform.position, transform.rotation);
            shieldMk1.transform.parent = transform;
            shieldHealth = 2;
            AbilitiesController.Instance.SetShieldHealth(shieldHealth);
            shieldExisting = true;
        }
        else if (GameStateController.Instance.shieldUpgrades[0])
        {
            shieldMk1 = Instantiate(shieldMk1, transform.position, transform.rotation);
            shieldMk1.transform.parent = transform;
            shieldHealth = 1;
            AbilitiesController.Instance.SetShieldHealth(shieldHealth);
            shieldExisting = true;
        }

    }

    void Update()
    {
        if (shieldHealth == 0 && shieldExisting)
        {
            Destroy(shieldMk1);
        }

        Weapon weapon = GetComponent<Weapon>();
        if (Input.GetButton("Fire1"))
        {
            if (GameStateController.Instance.multishotUpgrades[0])
            {
                weapon.Shoot(0.33f);
            }
            else
            {
                weapon.Shoot(1.0f);
            }
        }

        if (Input.GetButton("Fire2") && AbilitiesController.Instance.cooldown <= 0 && GameStateController.Instance.blastwaveUpgrades[0])
        {
            AudioSource.PlayClipAtPoint(blastwave, transform.position);
            blastwaveMk1 = Instantiate(blastwaveMk1, transform.position, transform.rotation);
            AbilitiesController.Instance.SetCooldown();
        }

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float depth = Camera.main.transform.position.y - transform.position.y;
        Vector3 mouseScreenSpacePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 mouseWorldSpacePos = Camera.main.ScreenToWorldPoint(mouseScreenSpacePos);
        transform.LookAt(mouseWorldSpacePos);

        Vector3 displacement = new Vector3(horizontalAxis, 0, verticalAxis) * Time.deltaTime * PlayerSpeed;
        displacement = transform.rotation * displacement;

        float distance = (mouseWorldSpacePos - transform.position).sqrMagnitude;
        if (distance < DistanceTreshold * DistanceTreshold && verticalAxis > 0)
            return;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + displacement);

        if (horizontalAxis < 0)
        {
            transform.Rotate(0, 0, -45 * horizontalAxis);
        }
        else if (horizontalAxis > 0)
        {
            transform.Rotate(0, 0, 45 * horizontalAxis);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Asteroid" || coll.gameObject.tag == "EnemyProjectile" || coll.gameObject.tag == "Boss")
        {
            if (shieldHealth == 0)
            {
                DestroyPlayer();
            }
            else
            {
                shieldHealth--;
                AbilitiesController.Instance.DecreaseShieldHealth();
            }
        }     
    }

    void DestroyPlayer()
    {
        GameObject fx = Instantiate(DestructionFx, transform.position, transform.rotation);
        Destroy(fx, DestructionFXTimeToLive);
        Debug.Log("Destroyed");
        Destroy(gameObject);
        AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
        GameStateController.Instance.OnPlayerDestroyed();
    }

}
