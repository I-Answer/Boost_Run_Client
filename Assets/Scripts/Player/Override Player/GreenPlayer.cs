using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : Player {

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        Debug.Log("Skill");
    }
}
