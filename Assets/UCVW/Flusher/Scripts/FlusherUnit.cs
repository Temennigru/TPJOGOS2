using UnityEngine;
using System.Collections;
using System;

public class FlusherUnit : SpriteUnit {

    private Animator animator;

    public int animSpeed;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int runState = Animator.StringToHash("Base Layer.Run");
    static int attackState = Animator.StringToHash("Base Layer.Attack");
    private AnimatorStateInfo currentBaseState;
    private UnityChanSoundPlayer soundPlayer;

    public override void MarkAsAttacking(Unit other) {
        base.MarkAsAttacking(other);
        soundPlayer.Play(0);
        animator.SetBool("Attacking", true);
    }

	public override void Initialize () {
        base.Initialize();
        animator = GetComponent<Animator>();
        if (animSpeed != 0) {
            animator.speed = animSpeed;
        } else {
            animator.speed = 1;
        }
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        soundPlayer = GetComponent<UnityChanSoundPlayer>();
	}
	
	void FixedUpdate () {
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        if(currentBaseState.nameHash == attackState) {
            if(!animator.IsInTransition(0)) {
                animator.SetBool("Attacking", false);
            }
        } else {
            if(isMoving) {
                animator.SetFloat("Speed", MovementSpeed);
            } else {
                animator.SetFloat("Speed", 0);
            }
        }
	}
}
