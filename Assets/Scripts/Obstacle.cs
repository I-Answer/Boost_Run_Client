using UnityEngine;

public class Obstacle : FieldObject {

    public ParticleSystem particle;

    protected override void OnCollision() {
        particle.Play();
        Destroy(gameObject);
        Player.Collision();
    }
}