using UnityEngine;

public class HPItem : Item {

    public float recoverHP;

    protected override void OnCollision() {
        base.OnCollision();
        Player.Hp = Mathf.Clamp(Player.Hp + recoverHP, 0.0f, 1.0f);
    }
}
