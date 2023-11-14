using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RespawnSimple : MonoBehaviour
{
    public GameObject character;
    public Vector3 initialPosition;

    public void Start()
    {
        // Set the initial position
        initialPosition = character.transform.position;
    }

    private void Update()
    {
        
    }

    public void RespawnThePlayer(CharacterController controller)
    {
        if (character.transform.position.y <= -15.0f)
        {
            controller.enabled = false;
            character.transform.position = initialPosition;
            controller.enabled = true;
        }
    }
}
