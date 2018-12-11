public class RedPlayer : Player {

    public float increaseHp;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        Hp += increaseHp;
    }
}
