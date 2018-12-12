using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : FieldObject {

    public int increaseSpeed;
    protected override void OnCollision()
    {
        Player.Speed += increaseSpeed;
    }
}
