using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlayer : Player {

    public PlayerSpeed mySpeed;
    public PlayerHp myHp;

    public uint changeSpeed;
    public float changeHp;

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
