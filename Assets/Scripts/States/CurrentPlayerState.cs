using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CurrentPlayerState
{
    public abstract void EnterState(States playerState);
    public abstract void UpdateState(States playerState);
    public abstract void FixedUpdateState(States playerState);
}
