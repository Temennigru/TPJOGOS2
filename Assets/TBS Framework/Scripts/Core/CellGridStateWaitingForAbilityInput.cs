using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CellGridStateWaitingForAbilityInput : CellGridState
{
    private Unit _unit;
    private List<Cell> _pathsInRange;
    private List<Unit> _unitsInRange;
    private Ability _ability;
    private HumanPlayer _player;

    private Cell _unitCell;



    public CellGridStateWaitingForAbilityInput(CellGrid cellGrid, HumanPlayer player, Unit unit, Ability ability) : base(cellGrid) {
        _unit = unit;
        _pathsInRange = new List<Cell>();
        _unitsInRange = new List<Unit>();
        _ability = ability;
        _player = player;
    }

    public override void OnCellClicked(Cell cell) {
        if (!_ability.CellTargetable) {return;}

        if(_pathsInRange.Contains(cell) && _unit.ActionPoints > 0) {
            var path = _unit.FindPath(_cellGrid.Cells, cell);
            _ability.activate(cell,path);
            _cellGrid.CellGridState = new CellGridStatePlayerTurn(_cellGrid, _player, _unit);
        }
    }

    public override void OnUnitDeselected(Unit unit)
    {
        base.OnUnitDeselected(unit);

        foreach (var _cell in _cellGrid.Cells)
        {
            _cell.UnMark();
        }
    }

    public override void OnUnitSelected(Unit unit)
    {
        base.OnUnitSelected(unit);
        if (!_ability.UnitTargetable) {return;}
        if (!_unitsInRange.Contains(unit)) {return;}

        var path = _unit.FindPath(_cellGrid.Cells, unit.Cell, true);

        foreach (var _cell in path)
        {
            _cell.MarkAsReachable();
        }
        unit.Cell.MarkAsPath();
    }
    public override void OnUnitClicked(Unit unit) {
        if (!_ability.UnitTargetable) {return;}

        if (_unitsInRange.Contains(unit) && _unit.ActionPoints > 0) {
            var path = _unit.FindPath(_cellGrid.Cells, unit.Cell, true);
            _ability.activate(unit, path);
            _cellGrid.CellGridState = new CellGridStatePlayerTurn(_cellGrid, _player, _unit);
        }

    }
    public override void OnCellDeselected(Cell cell)
    {
        base.OnCellDeselected(cell);

        foreach (var _cell in _cellGrid.Cells)
        {
            _cell.UnMark();
        }
    }
    public override void OnCellSelected(Cell cell)
    {
        base.OnCellSelected(cell);
        if (!_ability.CellTargetable) {return;}

        if (!_pathsInRange.Contains(cell)) return;

        var path = _unit.FindPath(_cellGrid.Cells, cell);
        foreach (var _cell in path)
        {
            _cell.MarkAsReachable();
        }
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        _unitCell = _unit.Cell;
        _pathsInRange = _unit.GetAvailableDestinations(_cellGrid.Cells, _ability.Range);

        if (_unit.ActionPoints <= 0) return;

        foreach (var currentUnit in _cellGrid.Units)
        {
            if (currentUnit.PlayerNumber.Equals(_unit.PlayerNumber))
                continue;
        
            if (_unit.Cell.GetDistance(currentUnit.Cell) <= _ability.Range) {
                currentUnit.SetState(new UnitStateMarkedAsReachableEnemy(currentUnit));
                _unitsInRange.Add(currentUnit);
            }
        }
    }
    public override void OnStateExit()
    {
        foreach (var cell in _cellGrid.Cells)
        {
            cell.UnMark();
        }   
    }
}

