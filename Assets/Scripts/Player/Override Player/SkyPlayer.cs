using UnityEngine;

public class SkyPlayer : Player {

    private int equipShieldCount = 0;
    private bool isShieldInit = false;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        equipShieldCount++;

        if (equipShieldCount <= 1)
            shieldObj.SetActive(true);
    }

    public override void Collision() {
        if (equipShieldCount > 0)
        {
            equipShieldCount--;
            if (equipShieldCount <= 0)
                shieldObj.SetActive(false);
        }
           
        else base.Collision();
    }
}
