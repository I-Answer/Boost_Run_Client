using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skill_UI : MonoBehaviour, IPointerDownHandler {

    private Player player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            player.UseSkill();
    }
#endif

    public void OnPointerDown(PointerEventData ped) {
        player.UseSkill();
    }
}
