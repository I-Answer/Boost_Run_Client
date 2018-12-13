﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RandomPooler : MonoBehaviour, IPlayerConnect {

    private readonly Vector3 appearZPos = new Vector3(0, 0, 600);

    private List<FieldObject> unusedObject;
    private List<Vector3> appearXPos;

    private Player player;
    public float distance;

    protected virtual void Awake() {
        unusedObject = new List<FieldObject>();

        for (int i = 0; i < transform.childCount; i++)
            unusedObject.Add(transform.GetChild(i).GetComponent<FieldObject>());

        appearXPos = new List<Vector3>();

        Vector3 temp = Vector3.zero;

        for (temp.x = -GameManager.distance; temp.x <= GameManager.distance; temp.x += GameManager.distance)
            appearXPos.Add(temp);
    }

    public void PlayerConnect(Player player) {
        this.player = player;
    }

    private IEnumerator Start() {
        while (true) {
            yield return CoroutineStorage.WaitForSeconds(GetWaitTime());

            OnActivate();
        }
    }

    protected abstract void OnActivate();

    public void Request() {
        GetRandomObject().Active(GetRandomXPos() + appearZPos);
    }

    public void Arrange(FieldObject obstacle) {
        unusedObject.Add(obstacle);
    }

    protected virtual Vector3 GetRandomXPos() {
        return appearXPos[Random.Range(0, appearXPos.Count)];
    }

    private FieldObject GetRandomObject() {
        FieldObject item = unusedObject[Random.Range(0, unusedObject.Count)];
        unusedObject.Remove(item);
        return item;
    }

    private float GetWaitTime() {
        if (player.Speed == 0) return 0.1f;

        return distance / player.Speed;
    }
}
