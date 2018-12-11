using System.Collections;

public class YellowPlayer : Player {

    public int loanSpeed;
    public float loanTime;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(LoanSpeed());
    }

    private IEnumerator LoanSpeed() {
        ChangeSpeed(Speed + loanSpeed);
        yield return CoroutineStorage.WaitForSeconds(loanTime);
        ChangeSpeed(Speed - loanSpeed);
    }
}
