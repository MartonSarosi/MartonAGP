using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class RespawnGhost : MonoBehaviour
{
    public GameObject ghost;
    public GameObject pirate;
    public Vector3 respawnPosition;

    public void Start()
    {
        
    }

    private void Update()
    {
        respawnPosition = pirate.transform.position;
        //Debug.Log("Setting ghost respawn position");
    }

    public void RespawnTheGhost(CharacterController controller)
    {
        if (ghost.transform.position.y <= -15.0f)
        {
            Debug.Log("Teleporting back");
            controller.enabled = false;
            ghost.transform.position = respawnPosition;
            controller.enabled = true;
        }
    }
}
