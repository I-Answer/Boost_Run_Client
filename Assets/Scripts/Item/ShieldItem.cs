using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : FieldObject {
    protected override void OnCollision()
    {
        Player.Shield = true;
    }
}
