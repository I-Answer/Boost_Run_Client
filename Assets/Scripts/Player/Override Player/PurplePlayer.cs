public class PurplePlayer : Player {

    public int boostScale;
    private bool useBoost;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();
        
        IncreaseScale *= boostScale;
        useBoost = true;
    }

    public override void Collision() {
        base.Collision();

        if (useBoost) {
            IncreaseScale = 1;
            useBoost = false;
        }
    }
}
