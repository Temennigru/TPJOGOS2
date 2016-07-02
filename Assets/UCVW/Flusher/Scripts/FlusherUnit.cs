using UnityEngine;
using System.Collections;

public class FlusherUnit : SpriteUnit {

    private Animator animator;

    public int animSpeed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        if (animSpeed != null) {
            animator.speed = animSpeed;
        } else {
            animator.speed = 1;
        }
        animator.Play("Idle", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving) {
            animator.Play("Run", 0);
        } else {
            animator.Play("Idle", 0);
        }
	}
}
