using UnityEngine;

public class Item : FieldObject {

    public AudioClip getSound;

    protected override void OnCollision() {
        SoundManager.PlaySound(getSound);
    }
}
