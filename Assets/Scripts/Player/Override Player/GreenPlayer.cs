using System.Collections;

public class GreenPlayer : Player {

    public float invincibleTime;
    private bool isInvincibilityMode;

    public override void UseSkill() {
        if (!CanUseSkill) return;

        base.UseSkill();

        StartCoroutine(Invincible());
    }

    private IEnumerator Invincible() {
        SetInvincibility(true);
        yield return CoroutineStorage.WaitForSeconds(invincibleTime);
        SetInvincibility(false);
    }

    private void SetInvincibility(bool isInvincible) {
        // TODO: 보호막 이펙트 설정 ex. 보호막 게임오브젝트.SetActive(isInvincible);
        isInvincibilityMode = isInvincible;
    }

    public override void Collision() {
        if (isInvincibilityMode) {
            // TODO: 보호막이 대신 맞아주는 이펙트
        }

        else base.Collision();
    }
}
