public class Obstacle : FieldObject {

    protected override void OnCollision() {
        GetPlayer.Collision();
    }
}