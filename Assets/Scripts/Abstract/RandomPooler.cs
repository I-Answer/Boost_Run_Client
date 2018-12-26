using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RandomPooler : MonoBehaviour, IPlayerConnect {

    private readonly Vector3 appearZPos = new Vector3(0, 0, 600);

    private List<FieldObject> unusedObject;
    private static PosGenerator posGenerator;

    private Player player;
    public float distance;

    private static bool isInit;

    private void Awake() {
        if (posGenerator == null)
            posGenerator = new PosGenerator();

        unusedObject = new List<FieldObject>();

        for (int i = 0; i < transform.childCount; i++)
            unusedObject.Add(transform.GetChild(i).GetComponent<FieldObject>());
    }

    public void PlayerConnect(Player player) {
        this.player = player;
    }

    private IEnumerator Start() {
        while (true) {
            yield return CoroutineStorage.WaitForSeconds(GetWaitTime());

            if (!isInit) {
                posGenerator.Init();
                isInit = true;
            }

            OnActivate();

            yield return null;
            
            if (isInit)
                isInit = false;
        }
    }

    protected abstract void OnActivate();

    public void Request() {
        GetRandomObject().Active(GetRandomXPos() + appearZPos);
    }

    public void Arrange(FieldObject obstacle) {
        unusedObject.Add(obstacle);
    }

    private Vector3 GetRandomXPos() {
        return posGenerator.GetRandomPos();
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
