using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Player {

    public PlayerHp myHp;
    public float increaseHp;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        myHp.IncreaseSpeed(increaseHp);
    }
}
