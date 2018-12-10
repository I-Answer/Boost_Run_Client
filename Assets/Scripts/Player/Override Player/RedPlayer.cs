using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Player {

    private PlayerHp playerHp;
    public float increaseHp;

    protected override void Awake() {
        base.Awake();

        playerHp = GetComponent<PlayerHp>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        playerHp.IncreaseSpeed(increaseHp);
    }
}
