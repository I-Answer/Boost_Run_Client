public class PinkPlayer : Player {

    public int changeSpeed;
    public float changeHp;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        if (Speed - changeSpeed >= 1800) SpeedToHp();
        else HpToSpeed();
    }

    private void SpeedToHp() {
        ChangeSpeed(Speed - changeSpeed);
        ChangeHp(Hp + changeHp);
    }

    private void HpToSpeed() {
        ChangeSpeed(Speed + changeSpeed);
        ChangeHp(Hp - changeHp);
    }
}
