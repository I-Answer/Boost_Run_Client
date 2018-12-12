using System.Collections;

public class YellowPlayer : Player {

    public int loanSpeed;
    public float loanTime;

    private int halfLoanSpeed;

    protected override void Awake() {
        base.Awake();

        halfLoanSpeed = loanSpeed / 2;
    }

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(LoanSpeed());
    }

    private IEnumerator LoanSpeed() {
        Speed += loanSpeed;
        yield return CoroutineStorage.WaitForSeconds(loanTime);
        Speed -= halfLoanSpeed;
    }
}
