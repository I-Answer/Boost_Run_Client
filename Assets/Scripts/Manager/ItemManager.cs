using System.Collections;
using UnityEngine;

public class ItemManager : RandomPooler {

    public GameObject Player;
    private Player playerInfo;
    public float appearProbability;

    protected override void OnActivate() {
        if (Random.Range(0f, 1f) > appearProbability) return;

        playerInfo = Player.GetComponent<Player>();
        Request();
    }

    public void IncreaseSpeed()
    {
        playerInfo.
    }
}
