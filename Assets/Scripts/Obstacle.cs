using UnityEngine;

public class Obstacle : FieldObject {

    public ParticleSystem particle;

    public AudioClip collisionSound;

    protected override void OnCollision() {
        SoundManager.PlaySound(collisionSound);

        particle.Play();
        Player.Collision();
    }
}