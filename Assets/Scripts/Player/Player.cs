using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    private new Transform transform;
    private PlayerSpeed speed;

    private Skill_UI skillUi;
    private ParticleSystem.MainModule particle;
    private Coroutine runningCoroutine;

    private Vector3 myPos;
    private uint mySpeed;

    public float skillCoolTime;
    private bool bCanUseSkill;

    protected virtual void Awake() {
        speed = GetComponent<PlayerSpeed>();
        speed.SpeedEvent = (speed) => mySpeed = speed;

        transform = gameObject.transform;

        skillUi = GameObject.FindWithTag("Skill Ui").GetComponent<Skill_UI>();
        particle = transform.Find("Fire").GetComponent<ParticleSystem>().main;
        myPos = transform.position;
    }

    private void Start() {
        StartCoroutine(CoolTime());
        skillUi.UpdateUI(skillCoolTime);
    }

    public void Move(Vector3 newPos) {
        myPos = newPos;

        if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);

        runningCoroutine = StartCoroutine(Moving());
    }

    private IEnumerator Moving() {
        while (!Mathf.Approximately(transform.position.x, myPos.x)) {
            transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * mySpeed * 0.01f);
            yield return null;
        }

        transform.position = myPos;
    }

    public virtual void UseSkill() {
        skillUi.UpdateUI(skillCoolTime);
        StartCoroutine(CoolTime());
    }

    private IEnumerator CoolTime() {
        bCanUseSkill = false;
        yield return CoroutineStorage.WaitForSeconds(skillCoolTime);
        bCanUseSkill = true;
    }

    public virtual void Collision() {
        speed.DecreaseSpeed();
    }

    // 파티클과 사운드 제어
    private void LateUpdate() {
        particle.startSpeed = -(mySpeed * 0.001f);
    }

    public Vector3 Position {
        get { return myPos; }
    }

    protected uint MySpeed {
        get { return mySpeed; }
    }

    protected bool CanUseSkill {
        get { return bCanUseSkill; }
    }
}
