using UnityEngine;

public class SpeedItem : FieldObject {

    public int increaseSpeed;
    public AudioClip collisionSound;

    protected override void OnCollision() {
        SoundManager.PlaySound(collisionSound);
        Player.Speed += increaseSpeed;
    }
}
