using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public TMP_Text shardText;

    // Start is called before the first frame update
    void Start()
    {
        shardText = GetComponent<TMP_Text>();
    }

    public void UpdateShardText(PlayerInventory inventory)
    {
        shardText.text = "Ghost Shards: " + inventory.NumberOfShards.ToString();
    }

    public void UpdateHealth(PlayerInventory inventory)
    {
        //update the healthbar in here
    }
}
