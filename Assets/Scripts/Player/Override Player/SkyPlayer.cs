public class SkyPlayer : Player {

    private int equipShieldCount = 0;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        equipShieldCount++;
    }

    public override void Collision() {
        if (equipShieldCount > 0)
            equipShieldCount--;

        else base.Collision();
    }
}
