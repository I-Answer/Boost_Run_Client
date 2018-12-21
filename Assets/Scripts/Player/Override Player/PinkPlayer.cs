public class PinkPlayer : Player {

    public int changeSpeed;
    public float changeHp;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        if (Speed - changeSpeed >= DecreaseBaseSpeed) SpeedToHp();
        else HpToSpeed();
    }

    private void SpeedToHp() {
        Speed -= changeSpeed;
        Hp += changeHp;
    }

    private void HpToSpeed() {
        Speed += changeSpeed;
        Hp -= changeHp;
    }
}
