﻿using System.Collections;
using UnityEngine;

public abstract class FieldObject : MonoBehaviour, IPlayerConnect {

    private new GameObject gameObject;
    private new Transform transform;

    private RandomPooler myPooler;

    private Player player;
    private Vector3 moveVec;

    private int playerSpeed;
    private bool isCollision;

    protected abstract void OnCollision();

    protected virtual void Awake() {
        gameObject = base.gameObject;
        transform = base.transform;

        myPooler = transform.parent.GetComponent<RandomPooler>();
        moveVec = Vector3.zero;
    }

    public void PlayerConnect(Player player) {
        this.player = player;
        gameObject.SetActive(false);
    }

    public void Active(Vector3 appearPos) {
        gameObject.SetActive(true);
        transform.localPosition = appearPos;

        isCollision = false;

        StartCoroutine(Move());
    }

    private IEnumerator Move() {
        while (transform.localPosition.z > 0f) {
            moveVec.z = player.Speed * 0.4f * Time.deltaTime;
            transform.position -= moveVec;

            if (IsCollision()) 
                OnCollision();

            yield return null;
        }

        myPooler.Arrange(this);
        gameObject.SetActive(false);
    }

    private bool IsCollision() {
        if (isCollision || transform.position.z > player.Position.z) return false;

        isCollision = true;

        return Mathf.Approximately(player.Position.x, transform.position.x);
    }

    protected Player Player {
        get { return player; }
    }
}
