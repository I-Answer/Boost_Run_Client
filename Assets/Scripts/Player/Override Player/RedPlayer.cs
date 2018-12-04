using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Player {

    private PlayerHp myHp;
    public float increaseHp;

    protected override void Awake() {
        base.Awake();

        myHp = GetComponent<PlayerHp>();
    }

    public override void UseSkill() {
        Debug.Log(myHp.Hp);
        myHp.ChangeHp(myHp.Hp + increaseHp);
    }
}
