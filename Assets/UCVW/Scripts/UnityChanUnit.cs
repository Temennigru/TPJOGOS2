using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class UnityChanUnit : Unit
{
    private Animator animator;
    private bool is_animation;
    public bool useCurves = true;
    public float useCurvesHeight = 0.5f;
    private CapsuleCollider col;
    private Rigidbody rb;
    private float orgColHight;
    private Vector3 orgVectColCenter;
    private AnimatorStateInfo currentBaseState;
    private UnityChanSoundPlayer soundPlayer;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Run");
    public override void Initialize()
    {
        base.Initialize();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        orgColHight = col.height;
        orgVectColCenter = col.center;
        transform.position += new Vector3(0, -0.1f, 0);
        animator = GetComponent<Animator>();
        animator.speed = 1;
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        soundPlayer = GetComponent<UnityChanSoundPlayer>();


        abilities.Add(GetComponent<MonkDashAbility>());
    }

    public override void OnUnitDeselected()
    {
        base.OnUnitDeselected();
        //StopCoroutine(PulseCoroutine);
        //transform.localScale = new Vector3(1,1,1);
    }

    public override void MarkAsAttacking(Unit other) {
        Rotate(other.Cell);
        if(!muteActions) {
            List<string> attacks = new List<string>();

            attacks.Add("Jab");
            attacks.Add("Hikick");

            float select = Random.value;
            string s = "";
            for(int i = 0; i < attacks.Count; i++) {
                if (select >= (i + 0.0)/attacks.Count && select < (i + 1.0)/attacks.Count) {
                    s = attacks[i];
                    break;
                }
            }
            select = Random.value;
            int sound = select > 0.5 ? 0 : 1;
            animator.SetTrigger(s);
            soundPlayer.Play(sound);
        }
    }
    public override void MarkAsDefending(Unit other)
    {
        if(!muteActions) {
            soundPlayer.Play(3);
            animator.SetTrigger("Damage");
        }
    }
    public override void MarkAsDestroyed()
    {
        animator.SetBool("Dead", true);
    }

    public override void MarkAsFriendly()
    {
    }
    public override void MarkAsReachableEnemy()
    {
    }
    public override void MarkAsSelected()
    {
    }
    public override void MarkAsFinished()
    {
    }
    public override void UnMark()
    {
    }


    // Update is called once per frame
    void Update () {
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        if (isMoving) {
            if(!muteActions) {
                animator.SetBool("Run", true);
            }
        } else {
            animator.SetBool("Run", false);
        }
    }

}

