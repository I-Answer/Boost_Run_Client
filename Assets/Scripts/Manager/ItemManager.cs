using UnityEngine;

public class ItemManager : RandomPooler {

    public ObstacleManager obstacleManager;
    public float appearProbability;
    
    private Vector3 curPos;

    protected override void OnActivate() {
        if (Random.Range(0f, 1f) <= appearProbability)
            Request();
    }

    protected override Vector3 GetRandomXPos() {
        do {
            curPos = base.GetRandomXPos();
        } while (curPos.Equals(obstacleManager.CurPos));

        return curPos;
    }

    public Vector3 CurPos {
        get { return curPos; }
    }
}
