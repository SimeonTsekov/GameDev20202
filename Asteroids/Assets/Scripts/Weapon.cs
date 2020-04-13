using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform WeaponPosition;
    public float ShotsPerSecond = 3.5f;

    private float LastShotTime = 0;
 
    public void Shoot(float cooldown)
    {
        float shotCooldown = cooldown / ShotsPerSecond;
        if (Time.time > LastShotTime + shotCooldown)
        {
            LastShotTime = Time.time;

            GameObject newProjectile = Instantiate(Projectile, WeaponPosition.position, WeaponPosition.rotation);
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),
                                     newProjectile.GetComponent<Collider>());
        }
    }
}
