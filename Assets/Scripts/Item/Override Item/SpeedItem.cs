public class SpeedItem : Item {

    public int increaseSpeed;

    protected override void OnCollision() {
        base.OnCollision();
        Player.Speed += increaseSpeed;
    }
}
