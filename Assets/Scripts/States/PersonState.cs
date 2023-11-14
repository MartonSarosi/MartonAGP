using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PersonState : CurrentPlayerState
{

    public override void EnterState(States playerState)
    {
        playerState.playerObject.SetActive(true);
        playerState.ghostObject.SetActive(false);
        playerState.controller = playerState.playerObject.GetComponent<CharacterController>();
        playerState.groundCheck = playerState.playerObject.GetComponentInChildren<GroundCheck>().transform;
        playerState.currentObject = playerState.playerObject.transform;

        playerState.SetSpeed(playerState.defaultSpeed);


        if (playerState.playerObject.GetComponentInChildren<Camera>(true) != null)
        {
            playerState.playerObject.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        }
    }

    public override void FixedUpdateState(States playerState)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(States playerState)
    {
        playerState.ghostObject.transform.position = playerState.playerObject.transform.position;
        playerState.ghostObject.transform.rotation = playerState.playerObject.transform.rotation;


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerState.TransitionToState(playerState.ghostState);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerState.playerObject.TryGetComponent<Slingshot>(out Slingshot slingshot))
            {
                slingshot.DoSlingshot(playerState.controller);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerState.playerObject.TryGetComponent<PlayerPickUpDrop>(out PlayerPickUpDrop playerpickupdrop))
            {
                playerpickupdrop.PickUpOrDrop(playerState.controller);
            }
        }

        if (playerState.playerObject.TryGetComponent<ClimbLedge>(out ClimbLedge climbledge))
        {
            climbledge.Climb(playerState.controller);
        }

        if (playerState.playerObject.TryGetComponent<RespawnSimple>(out RespawnSimple respawn))
        {
            respawn.RespawnThePlayer(playerState.controller);
        }
    }

}
