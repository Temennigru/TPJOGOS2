using UnityEngine;

class Cube : Square
{
    private Renderer rend;
    public Shader shader_unselected;
    public Shader shader_selected;
    public Shader shader_path;
    public Shader shader_reachable;


    public void Start()
    {
        rend = GetComponent<Renderer>();
        if (shader_unselected == null) {
            shader_unselected = Shader.Find("Sprites/Diffuse");
        }
        if (shader_selected == null) {
            shader_selected = Shader.Find("Unlit/Color");
        }
        if (shader_path == null) {
            shader_path = Shader.Find("Unlit/Color");
        }
        if (shader_reachable == null) {
            shader_reachable = Shader.Find("Unlit/Color");
        }


        rend.material.shader = shader_unselected;
    }

    public override Vector3 GetCellDimensions()
    {
        return GetComponent<Renderer>().bounds.size;
    }

    public override void MarkAsHighlighted()
    {
        rend.material.color = new Color(0.1f, 0.1f, 0.1f); ;
        //rend.material.color = Color.green;
        rend.material.shader = shader_selected;
    }

    public override void MarkAsPath()
    {
        rend.material.color = new Color(0.1f, 0.1f, 0.1f); ;
        rend.material.color = Color.green;
        rend.material.shader = shader_path;
    }

    public override void MarkAsReachable()
    {
        rend.material.color = new Color(0.1f, 0.1f, 0.1f); ;
        rend.material.color = Color.yellow;
        rend.material.shader = shader_reachable;
    }

    public override void UnMark()
    {
        rend.material.color = Color.white;
        rend.material.shader = shader_unselected;
    }
}

