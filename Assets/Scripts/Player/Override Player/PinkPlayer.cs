using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlayer : Player {

    private PlayerSpeed playerSpeed;
    private PlayerHp playerHp;

    public uint changeSpeed;
    public float changeHp;

    protected override void Awake() {
        base.Awake();

        playerSpeed = GetComponent<PlayerSpeed>();
        playerHp = GetComponent<PlayerHp>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        if (MySpeed - changeSpeed >= 1800) SpeedToHp();
        else HpToSpeed();
    }

    private void SpeedToHp() {
        playerSpeed.ChangeSpeed(MySpeed - changeSpeed);
        playerHp.ChangeHp(playerHp.Hp + changeHp);
    }

    private void HpToSpeed() {
        playerSpeed.ChangeSpeed(MySpeed + changeSpeed);
        playerHp.ChangeHp(playerHp.Hp - changeHp);
    }
}
