using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    private new Transform transform;

    private GameManager manager;

    private Hp_UI hpUi;
    private Speed_UI speedUi;
    private Skill_UI skillUi;

    private Coroutine runningCoroutine;

    public Sprite skillImage;
    public float skillCoolTime;
    private bool bCanUseSkill;

    private Vector3 myPos;

    private void Awake() {
        transform = base.transform;

        manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        
        hpUi = GameObject.FindWithTag("Hp Ui").GetComponent<Hp_UI>();
        speedUi = GameObject.FindWithTag("Speed Ui").GetComponent<Speed_UI>();

        skillUi = GameObject.FindWithTag("Skill Ui").GetComponent<Skill_UI>();
        skillUi.SetSkillImage(skillImage);

        myPos = transform.position;

        hp = 1f;
        bAlive = true;
    }

    private void Start() {
        StartCoroutine(CoolTime());

        StartCoroutine(UpdateSpeed());
        StartCoroutine(UpdateHp());
    }

    public void Move(Vector3 newPos) {
        myPos = newPos;

        if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);

        runningCoroutine = StartCoroutine(Moving());
    }

    private IEnumerator Moving() {
        while (!Mathf.Approximately(transform.position.x, myPos.x)) {
            transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * speed * 0.01f);
            yield return null;
        }

        transform.position = myPos;
    }

    public virtual void Collision() {
        Speed -= GetCollisionSpeed();
    }

    public virtual void UseSkill() {
        StartCoroutine(CoolTime());
    }

    private IEnumerator CoolTime() {
        skillUi.UpdateUi(skillCoolTime);

        bCanUseSkill = false;
        yield return CoroutineStorage.WaitForSeconds(skillCoolTime);
        bCanUseSkill = true;
    }

    public Vector3 Position {
        get { return myPos; }
    }

    protected bool CanUseSkill {
        get { return bCanUseSkill; }
    }
}
