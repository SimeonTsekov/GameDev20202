using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    public float DistanceTreshold = 0.15f;

    private void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(gameObject);
    }

    void Update()
    {
        Weapon weapon = GetComponent<Weapon>();
        if (Input.GetButton("Fire1"))
        {
            weapon.Shoot();
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

    private void OnDestroy()
    {
        AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
        //GameStateController.Instance.OnPlayerDestroyed();
    }
}
