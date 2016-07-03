using UnityEngine;

class Cube : Square
{
    private Renderer rend;
    public Material unselected;
    public Material selected;
    public Material path;
    public Material reachable;


    public void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material = unselected;
    }

    public override Vector3 GetCellDimensions()
    {
        return GetComponent<Renderer>().bounds.size;
    }

    public override void MarkAsHighlighted()
    {
        rend.material = selected;
    }

    public override void MarkAsPath()
    {
        rend.material = path;
    }

    public override void MarkAsReachable()
    {
        rend.material = reachable;
    }

    public override void UnMark()
    {
        rend.material = unselected;
    }
}

