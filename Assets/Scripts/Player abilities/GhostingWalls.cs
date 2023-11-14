using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GhostingWalls : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float wallPassSpeed = 20f;
    public float wallPassDuration = 1f;
    public LayerMask wallLayer;
    public KeyCode wallPassKey = KeyCode.R;

    private bool isWallPassing = false;
    private float wallPassTimer = 0f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(wallPassKey))
        {
            isWallPassing = true;
            wallPassTimer = wallPassDuration;
            gameObject.layer = 9;
        }

        if (isWallPassing)
        {
            //Vector3 move = transform.right * characterController.moveDirection.x + transform.forward * moveDirection.y;

            //characterController.Move(move * wallPassSpeed * Time.deltaTime);
            wallPassTimer -= Time.deltaTime;
            if (wallPassTimer <= 0f)
            {
                isWallPassing = false;
                gameObject.layer = 8;
            }
        }
    }
}