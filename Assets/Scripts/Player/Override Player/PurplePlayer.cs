public class PurplePlayer : Player {

    public int boostScale;
    private bool bBoost;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();
        
        IncreaseScale *= boostScale;
        bBoost = true;
    }

    public override void Collision() {
        base.Collision();

        if (bBoost) {
            IncreaseScale = 1;
            bBoost = false;
        }
    }
}
