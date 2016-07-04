using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class Ability : MonoBehaviour {

    public int Range {get; set;}
    public bool UnitTargetable {get; set;}
    public bool CellTargetable {get; set;}
    public bool Piercing {get; set;}

    public abstract void activate(Unit target, List<Cell> path);
    public abstract void activate(Cell target, List<Cell> path);

    public Ability(int range, bool unitTargetable, bool cellTargetable, bool piercing) {
        Range = range;
        CellTargetable = unitTargetable;
        UnitTargetable = cellTargetable;
        Piercing = piercing;
    }
}
