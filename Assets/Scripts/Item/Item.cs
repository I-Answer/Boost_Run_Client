using UnityEngine;

public class Item : FieldObject {

    protected override void OnCollision() {
        Debug.Log("Get Item");
    }
}
