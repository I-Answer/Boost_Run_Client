using UnityEngine;

public class ShieldItem : FieldObject {

    public AudioClip collisionSound;
    protected override void OnCollision() {
        SoundManager.PlaySound(collisionSound);
        Player.Shield = true;
    }
}
