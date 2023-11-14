using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Slingshot player;
    public CharacterController PlayerController;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SendMessage("SwitchBehaviours");
        }
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.SendMessage("DoSlingshot");
        }
    }
}
