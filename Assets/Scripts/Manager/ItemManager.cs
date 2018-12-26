using UnityEngine;

public class ItemManager : RandomPooler {

    public float appearProbability;

    protected override void OnActivate() {
        if (Random.Range(0f, 1f) <= appearProbability)
            Request();
    }
}
