using System.Collections;
using UnityEngine;

public class GreenPlayer : Player {

    public GameObject shieldObj;
    private GameObject shield;

    public float invincibleTime;
    private bool isInvincibilityMode;
    private bool isShieldInit = false;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        if(!isShieldInit)
        {
            shield = Instantiate(shieldObj, base.transform);
            isShieldInit = true;
        }

        StartCoroutine(Invincible());
    }

    private IEnumerator Invincible() {
        SetInvincibility(true);
        yield return CoroutineStorage.WaitForSeconds(invincibleTime);
        SetInvincibility(false);
    }

    private void SetInvincibility(bool isInvincible) {
        shield.SetActive(isInvincible);
        isInvincibilityMode = isInvincible;
    }

    public override void Collision() {
        if (isInvincibilityMode) {
            // TODO: 보호막이 대신 맞아주는 이펙트
        }

        else base.Collision();
    }
}
