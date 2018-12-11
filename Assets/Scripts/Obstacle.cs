public class Obstacle : FieldObject {

    protected override void OnCollision() {
        Player.Collision();
    }
}