using System.Collections;
using System.Collections.Generic;
using Source.YetAnotherStateMachine.General;
using Source.YetAnotherStateMachine.PlayerSpecific;
using UnityEngine;

public class PlayerHurtHandler : StateHandler<PlayerState>
{
    public override PlayerState ThisState => PlayerState.Hurt;
    
    
}
