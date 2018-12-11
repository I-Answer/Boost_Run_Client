using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill_UI : MonoBehaviour, IPointerDownHandler {

    private Image myImage, backgroundImage;
    private Player player;

    private float inverseCooltime = 0f;

    private void Awake() {
        myImage = GetComponent<Image>();
        backgroundImage = transform.parent.GetComponent<Image>();
    }

#if UNITY_EDITOR
    private IEnumerator Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        while (true) {
            if (Input.GetKeyDown(KeyCode.Space))
                player.UseSkill();

            yield return null;
        }
    }
#endif

    public void OnPointerDown(PointerEventData ped) {
        player.UseSkill();
    }

    public void UpdateUI(float coolTime) {
        StartCoroutine(FillUI(coolTime));
    }

    private IEnumerator FillUI(float coolTime) {
        if (inverseCooltime == 0f)
            inverseCooltime = 1f / coolTime;

        for (float nowGage = 0f; nowGage <= coolTime; nowGage += Time.deltaTime) {
            myImage.fillAmount = nowGage * inverseCooltime;
            yield return null;
        }

        myImage.fillAmount = 1f;
    }

    public void SetSkillImage(Sprite image) {
        myImage.sprite = backgroundImage.sprite = image;
    }
}
