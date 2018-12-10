using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlayer : Player {

    private PlayerSpeed mySpeed;
    private PlayerHp myHp;

    public uint changeSpeed;
    public float changeHp;

    protected override void Awake() {
        base.Awake();

        mySpeed = GetComponent<PlayerSpeed>();
        myHp = GetComponent<PlayerHp>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        if (MySpeed - changeSpeed >= 1800) SpeedToHp();
        else HpToSpeed();
    }

    private void SpeedToHp() {
        mySpeed.ChangeSpeed(MySpeed - changeSpeed);
        myHp.ChangeHp(myHp.Hp + changeHp);
    }

    private void HpToSpeed() {
        mySpeed.ChangeSpeed(MySpeed + changeSpeed);
        myHp.ChangeHp(myHp.Hp - changeHp);
    }
}
