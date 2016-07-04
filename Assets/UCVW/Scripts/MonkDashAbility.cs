using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonkDashAbility : Ability {

    private Animator animator;
    private Unit unit;
    private UnityChanSoundPlayer soundPlayer;

    public MonkDashAbility() : base(3, true, true, false) {}

    void Start() {
        animator = GetComponent<Animator>();
        unit = GetComponent<Unit>();
        soundPlayer = GetComponent<UnityChanSoundPlayer>();
    }

    private IEnumerator waitFinishMovementCell() {
        while(unit.isMoving) {yield return 0;}
        unit.muteActions = false;
        animator.SetBool("MuteActions", false);
    }
    private IEnumerator waitFinishMovementUnit(Unit enemy) {
        while(unit.isMoving) {yield return 0;}
        unit.DealDamage(enemy, true); // Action points already subtracted when moving
        unit.muteActions = false;
        animator.SetBool("MuteActions", false);
    }


    public override void activate(Unit target, List<Cell> path) {

        if(!path.Contains(target.Cell)) {
            return;
        }
        Cell temp;
        if(path.Count > 1) {
            temp = path[1];
            path = new List<Cell>();
            path.Add(temp);
            unit.muteActions = true;
            animator.SetBool("MuteActions", true);
            unit.Move(temp, path, 1);
        }


        animator.SetTrigger("ScrewK");
        soundPlayer.Play(2);
        StartCoroutine(waitFinishMovementUnit(target));
    }

    public override void activate(Cell target, List<Cell> path) {

        path = new List<Cell>();
        path.Add(target);

        unit.muteActions = true;
        animator.SetBool("MuteActions", true);
        animator.SetTrigger("Slide");
        unit.Move(target, path, 1);
        StartCoroutine(waitFinishMovementCell());
    }

}
