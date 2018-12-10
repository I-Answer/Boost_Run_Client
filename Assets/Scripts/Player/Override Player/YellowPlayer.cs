using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : Player {

    private PlayerSpeed mySpeed;

    public uint loanSpeed;
    public float loanTime;

    protected override void Awake() {
        base.Awake();

        mySpeed = GetComponent<PlayerSpeed>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(LoanSpeed());
    }

    private IEnumerator LoanSpeed() {
        mySpeed.ChangeSpeed(MySpeed + loanSpeed);
        yield return CoroutineStorage.WaitForSeconds(loanTime);
        mySpeed.ChangeSpeed(MySpeed - loanSpeed);
    }
}
