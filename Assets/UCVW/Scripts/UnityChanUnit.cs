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
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int restState = Animator.StringToHash("Base Layer.Rest");

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
        animator.Play("Idle", 0);
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
    }

    public override void OnUnitDeselected()
    {
        base.OnUnitDeselected();
        //StopCoroutine(PulseCoroutine);
        //transform.localScale = new Vector3(1,1,1);
    }

    public override void MarkAsAttacking(Unit other)
    {
    }
    public override void MarkAsDefending(Unit other)
    {
    }
    public override void MarkAsDestroyed()
    {
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
            animator.SetFloat("Speed", MovementSpeed);
        } else {
            animator.SetFloat("Speed", 0);
        }
    }

}

