using UnityEngine;

public class UCVWGUIController : MonoBehaviour
{
    public HumanPlayer mainPlayer;
    public CellGrid CellGrid;
    
    void Start()
    {
        Debug.Log("Press 'n' to end turn");
    }

    void Update ()
    {
        /*if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Ending turn");
            CellGrid.EndTurn();//User ends his turn by pressing "n" on keyboard.
        }*/
    }
}
