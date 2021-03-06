﻿using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    public const int DecreaseBaseSpeed = 1800;

    private new Transform transform;

    private GameManager manager;

    private Hp_UI hpUi;
    private Speed_UI speedUi;
    private Skill_UI skillUi;

    public AudioClip collisionSound;
    private Coroutine runningCoroutine;

    public Sprite skillImage;
    public float skillCoolTime;
    private bool isCanUseSkill;

    private Vector3 myPos;

    public GameObject shieldObj;
    private int shieldCount;

    protected virtual void Awake() {
        transform = base.transform;

        manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        
        hpUi = GameObject.FindWithTag("Hp Ui").GetComponent<Hp_UI>();
        speedUi = GameObject.FindWithTag("Speed Ui").GetComponent<Speed_UI>();

        skillUi = GameObject.FindWithTag("Skill Ui").GetComponent<Skill_UI>();
        skillUi.SetSkillImage(skillImage);

        myPos = transform.position;

        hp = 1f;
        isAlive = true;
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
        if (shieldCount > 0) {
            shieldCount--;
            if (shieldCount == 0)
                shieldObj.SetActive(false);
        }

        else {
            Speed -= GetCollisionSpeed();
            SoundManager.PlaySound(collisionSound);
        }
    }

    public virtual void UseSkill() {
        StartCoroutine(CoolTime());
    }

    private IEnumerator CoolTime() {
        skillUi.UpdateUi(skillCoolTime);

        isCanUseSkill = false;
        yield return CoroutineStorage.WaitForSeconds(skillCoolTime);
        isCanUseSkill = true;
    }

    public Vector3 Position {
        get { return myPos; }
    }

    protected bool CanUseSkill {
        get { return isCanUseSkill; }
    }

    public void GetShield() {
        shieldCount++;
        if (shieldCount == 1)
            shieldObj.SetActive(true);
    }
}
