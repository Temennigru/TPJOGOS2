﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomUnitGenerator : MonoBehaviour, IUnitGenerator
{
    public Transform UnitsParent;
    public Transform CellsParent;

    /// <summary>
    /// Returns units that are already children of UnitsParent object.
    /// </summary>
    public List<Unit> SpawnUnits(List<Cell> cells)
    {
        List<Unit> ret = new List<Unit>();
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var unit = UnitsParent.GetChild(i).GetComponent<Unit>();
            if(unit !=null) {
                var cell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
                if (!cell.IsTaken) { //Unit gets snapped to the nearest cell
                    cell.IsTaken = true;
                    unit.Cell = cell;
                    Vector3 offset = new Vector3(0,cell.GetComponent<Cell>().GetCellDimensions().y, 0);
                    unit.transform.position = new Vector3(cell.transform.position.x, unit.transform.position.y, cell.transform.position.z);
                    unit.Initialize();
                    ret.Add(unit);
                } else { //If the nearest cell is taken, the unit gets destroyed.
                    //Destroy(unit.gameObject);
                }
            } else {
                Debug.LogError("Invalid object in Units Parent game object");
            }
            
        }
        return ret;
    }

    public void SnapToGrid()
    {
        List<Transform> cells = new List<Transform>();

        foreach(Transform cell in CellsParent)
        {
            cells.Add(cell);
        }

        foreach(Transform unit in UnitsParent)
        {
            var closestCell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
            if (!closestCell.GetComponent<Cell>().IsTaken)
            {
                Vector3 offset = new Vector3(0,closestCell.GetComponent<Cell>().GetCellDimensions().y, 0);
                unit.position = closestCell.transform.position + offset;
            }//Unit gets snapped to the nearest cell
        }
    }
}

