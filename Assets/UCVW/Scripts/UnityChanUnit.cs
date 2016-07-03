using System.Collections;
using UnityEngine;

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
        Debug.Log(1/2);
    }

    public override void OnUnitDeselected()
    {
        base.OnUnitDeselected();
        //StopCoroutine(PulseCoroutine);
        //transform.localScale = new Vector3(1,1,1);
    }

    public override void MarkAsAttacking(Unit other) {
        Rotate(other.Cell);
        List<string> attacks = new List<string>();

        attacks.Add("Jab");
        attacks.Add("Hikick");

        float select = Random.value();
        string s = "";
        for(int i = 0; i < attacks.Count; i++) {
            if (select >= i/attacks.Count && select < (i + 1)/attacks.Count) {
                s = attacks[i];
            }
        }
        animator.setTrigger(s);
    }
    public override void MarkAsDefending(Unit other)
    {
        animator.setTrigger("DamageDown");
    }
    public override void MarkAsDestroyed()
    {
        animator.setBool("Dead");
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
        if (isMoving) {
            animator.SetBool("Run", true);
        } else {
            animator.SetBool("Run", false);
        }
    }

}

