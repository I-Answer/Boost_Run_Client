using UnityEngine;

public class Obstacle : FieldObject {

    public ParticleSystem particle;

    protected override void OnCollision() {
        Destroy(gameObject);
        particle.Play();
        Player.Collision();
    }
}