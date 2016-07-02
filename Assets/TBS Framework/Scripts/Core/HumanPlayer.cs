using UnityEngine;
class HumanPlayer : Player
{
    protected Unit _character;

    public override void Play(CellGrid cellGrid) {
        foreach (var currentUnit in cellGrid.Units) {
            if (currentUnit.PlayerNumber == PlayerNumber) {
                _character = currentUnit;
                break;
            }
        }
    
        cellGrid.CellGridState = new CellGridStatePlayerTurn(cellGrid, _character);
    }
}