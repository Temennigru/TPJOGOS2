using UnityEngine;

public class UCVWGUIController : MonoBehaviour
{
    public HumanPlayer mainPlayer;
    public CellGrid CellGrid;
    
    void Start()
    {
        //Debug.Log("Press 'n' to end turn");
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            //Debug.Log("Ending turn");
            CellGrid.CellGridState = new CellGridStateWaitingForAbilityInput(CellGrid, mainPlayer, mainPlayer.character, mainPlayer.character.abilities[0]);
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            CellGrid.CellGridState = new CellGridStatePlayerTurn(CellGrid, mainPlayer, mainPlayer.character);
        }
    }
}
