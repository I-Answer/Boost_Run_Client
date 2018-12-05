using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlayer : Player {

    public override void UseSkill(System.Action<float> ChangeUI) {
        if (!CanUseSkill) return;

        base.UseSkill(ChangeUI);

        Debug.Log("Skill");
    }
}
