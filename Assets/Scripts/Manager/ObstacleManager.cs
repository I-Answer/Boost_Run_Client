using UnityEngine;

public class ObstacleManager : RandomPooler {

    public ItemManager itemManager;
    private Vector3 beforePos, curPos;

    protected override void OnActivate() {
        Request();
    }

    protected override Vector3 GetRandomXPos() {
        do {
            curPos = base.GetRandomXPos();
        } while (curPos.Equals(beforePos) || curPos.Equals(itemManager.CurPos));

        beforePos = curPos;

        return curPos;
    }

    public Vector3 CurPos {
        get { return curPos; }
    }
}
