using UIHealthAlchemy;

public class Hp_UI : PowerBarMaterial, IPlayerUi<float> {

    public void UpdateUi(float hp) {
        Value = hp;
    }
}
