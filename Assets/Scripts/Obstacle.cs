using UnityEngine;

public class Obstacle : FieldObject {

    public ParticleSystem particle;

    protected override void OnCollision() {
        particle.Play();
        Player.Collision();
    }
}