using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : Player {

    public PlayerSpeed mySpeed;

    public uint loanSpeed;
    public float loanTime;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(mySpeed.LoanSpeed(loanSpeed, loanTime));
    }
}
