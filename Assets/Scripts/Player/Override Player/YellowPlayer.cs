using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : Player {

    private PlayerSpeed playerSpeed;

    public uint loanSpeed;
    public float loanTime;

    protected override void Awake() {
        base.Awake();

        playerSpeed = GetComponent<PlayerSpeed>();
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(LoanSpeed());
    }

    private IEnumerator LoanSpeed() {
        playerSpeed.ChangeSpeed(MySpeed + loanSpeed);
        yield return CoroutineStorage.WaitForSeconds(loanTime);
        playerSpeed.ChangeSpeed(MySpeed - loanSpeed);
    }
}
