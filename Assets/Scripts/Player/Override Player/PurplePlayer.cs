using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlayer : Player {

    private PlayerSpeed mySpeed;
    public uint boostScale;

    private bool bBoost;

    protected override void Awake() {
        base.Awake();

        mySpeed = GetComponent<PlayerSpeed>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        mySpeed.IncreaseScale *= boostScale;
        bBoost = true;
    }

    public override void Collision() {
        base.Collision();

        if (bBoost) {
            mySpeed.IncreaseScale = 1;
            bBoost = false;
        }
    }
}
