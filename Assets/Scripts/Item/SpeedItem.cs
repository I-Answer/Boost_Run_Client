public class SpeedItem : FieldObject {

    public int increaseSpeed;

    protected override void OnCollision() {
        Player.Speed += increaseSpeed;
    }
}
