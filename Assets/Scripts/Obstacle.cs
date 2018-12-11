public class Obstacle : FieldObject {

    protected override void OnCollision() {
        GameManager.Player.Collision();
    }
}