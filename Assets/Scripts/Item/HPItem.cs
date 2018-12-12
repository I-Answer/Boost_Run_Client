using UnityEngine;

public class HPItem : FieldObject {
    public float recoverHP;

    protected override void OnCollision() {
        Player.Hp = Mathf.Clamp(Player.Hp + recoverHP, 0.0f, 1.0f);
    }
}
