using UnityEngine;

public class ObstacleManager : RandomPooler {

    public float appearProbability;

    protected override void OnActivate() {
        if (Random.Range(0f, 1f) <= appearProbability)
            Request();

        Request();
    }
}
