public class ShieldItem : Item {

    protected override void OnCollision() {
        base.OnCollision();
        Player.GetShield();
    }
}
