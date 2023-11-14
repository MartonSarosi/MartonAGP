using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostState : CurrentPlayerState
{
    public override void EnterState(States playerState)
    {
        playerState.ghostObject.SetActive(true);
        playerState.controller = playerState.ghostObject.GetComponent<CharacterController>();
        playerState.groundCheck = playerState.ghostObject.GetComponentInChildren<GroundCheck>().transform;
        playerState.currentObject = playerState.ghostObject.transform;

        playerState.SetSpeed(playerState.ghostSpeed);

        if (playerState.playerObject.GetComponentInChildren<Camera>() != null)
        {
            playerState.playerObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }

        //playerState.ghostObject.TryGetComponent<GhostTimer>(out GhostTimer timer)
        //{
              //TimerOn = true;
        //}
    }

    public override void FixedUpdateState(States playerState)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(States playerState)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerState.TransitionToState(playerState.personState);
        }

        if (Input.GetKeyDown(playerState.wallPassKey))
        {
            playerState.isWallPassing = true;
            playerState.wallPassTimer = playerState.wallPassDuration;
            playerState.ghostObject.gameObject.layer = 9;
        }

        if (playerState.isWallPassing)
        {
            Vector3 move = playerState.ghostObject.transform.right * playerState.moveDirection.x + playerState.ghostObject.transform.forward * playerState.moveDirection.y;

            playerState.controller.Move(move * playerState.wallPassSpeed * Time.deltaTime);
            playerState.wallPassTimer -= Time.deltaTime;
            if (playerState.wallPassTimer <= 0f)
            {
                playerState.isWallPassing = false;
                playerState.ghostObject.gameObject.layer = 8;
            }
        }
        // Check if the player is colliding with a wall and if the wall pass condition is not met
        //if (!playerState.isWallPassing && Physics.CheckSphere(playerState.ghostObject.transform.position, playerState.controller.radius, playerState.wallLayer))
        //{
        //    // If the condition is not met, prevent the player from moving into the wall
        //    playerState.controller.SimpleMove(Vector3.zero);
        //}

        if (playerState.ghostObject.TryGetComponent<RespawnGhost>(out RespawnGhost respawn))
        {
            respawn.RespawnTheGhost(playerState.controller);
        }

        if (playerState.ghostObject.TryGetComponent<GhostTimer>(out GhostTimer timer))
        {
            timer.GhostTimerOn(playerState.controller);
        }

        if (playerState.ghostObject.TryGetComponent<GhostTimer>(out GhostTimer stop))
        {
            if (stop.TimerOn == false)
            {
                playerState.TransitionToState(playerState.personState);
            }
        }
    }
}
