using UnityEngine;

public class SkyPlayer : Player {

    public GameObject shieldObj;
    private GameObject shield;
    private int equipShieldCount = 0;
    private bool isShieldInit = false;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();
        if(!isShieldInit)
        {
            shield = Instantiate(shieldObj, base.transform);
            isShieldInit = true;
        }
        equipShieldCount++;

        if (equipShieldCount <= 1)
            shield.SetActive(true);
    }

    public override void Collision() {
        if (equipShieldCount > 0)
        {
            equipShieldCount--;
            if (equipShieldCount <= 0)
                shield.SetActive(false);
        }
           
        else base.Collision();
    }
}
