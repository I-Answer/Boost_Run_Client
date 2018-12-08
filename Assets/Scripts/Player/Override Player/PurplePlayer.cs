using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlayer : Player {

    public PlayerSpeed playerSpeed;
    public uint boostScale;

    private bool bBoost;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        playerSpeed.IncreaseScale *= boostScale;
        bBoost = true;
    }

    public override void Collision() {
        base.Collision();

        if (bBoost) {
            playerSpeed.IncreaseScale = 1;
            bBoost = false;
        }
    }
}
