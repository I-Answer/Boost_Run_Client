public class ShieldItem : FieldObject {

    protected override void OnCollision() {
        Player.Shield = true;
    }
}
