using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HumanPlayer : Player
{
    public Unit character;
    public bool endTurn = false;
    private CellGrid _cellGrid;

    public override void Play(CellGrid cellGrid) {
        _cellGrid = cellGrid;
        /*
        foreach (var currentUnit in cellGrid.Units) {
            if (currentUnit.PlayerNumber == PlayerNumber) {
                _character = currentUnit;
                break;
            }
        }*/
    
        cellGrid.CellGridState = new CellGridStatePlayerTurn(cellGrid, this, character);
    }

    public void EndTurn() {
        StartCoroutine(WaitForEnd());
    }

    protected virtual IEnumerator WaitForEnd() {
        while (character.isMoving) {
            yield return 0;
        }
        _cellGrid.EndTurn();
    }
}