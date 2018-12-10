using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Player {

    private PlayerHp myHp;
    public float increaseHp;

    protected override void Awake() {
        base.Awake();

        myHp = GetComponent<PlayerHp>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        myHp.IncreaseSpeed(increaseHp);
    }
}
