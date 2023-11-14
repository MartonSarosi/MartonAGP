using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfShards { get; private set; }

    public UnityEvent<PlayerInventory> OnShardCollected;

    public void ShardCollected()
    {
        NumberOfShards++;
        OnShardCollected.Invoke(this);
    }
}
