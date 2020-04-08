using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour
{
    public ParticleSystem propulsion1;
    public ParticleSystem propulsion2;
    void Start()
    {
    }

    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (verticalAxis > 0 && horizontalAxis == 0)
        {
            propulsion1.Emit(1);
            propulsion2.Emit(1);
        } else if (horizontalAxis > 0)
        {
            propulsion1.Emit(1);
        } else if (horizontalAxis < 0)
        {
            propulsion2.Emit(1);
        }
    }
}
