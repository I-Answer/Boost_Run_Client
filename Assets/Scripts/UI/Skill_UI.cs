using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill_UI : MonoBehaviour, IPointerDownHandler {

    private Image myImage;
    private Player player;

    private void Awake() {
        myImage = GetComponent<Image>();
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

    public void UpdateUI(float coolTime) {
        StartCoroutine(FillUI(coolTime));
    }

    private IEnumerator FillUI(float coolTime) {
        float inverseCoolTime = 1f / coolTime;

        for (float nowGage = 0f; nowGage <= coolTime; nowGage += Time.deltaTime) {
            myImage.fillAmount = nowGage * inverseCoolTime;
            yield return null;
        }

        myImage.fillAmount = 1f;
    }
}
