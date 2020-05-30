using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    #region Variables
    // Boolean to check if a tile is selected
    public bool isSelected;
    // Boolean to check if a tile is selectable
    public bool isSelectable;
    // Boolean to check if a tile is for the first time
    public bool isFirstTime;
    public GridManager theGridManager;
    public GameObject parent;
    #endregion
    public void ButtonClicked()
    {
        // Activates when user deselect the tile for the first time
        if(isSelectable && !isSelected && isFirstTime)
        {
            // Make the tile selected and changes the color to the red
            isSelected = !isSelected;
            gameObject.GetComponentInChildren<Text>().color = Color.red;
            
            // Makes all the other tiles not selectable 
            for(int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponentInChildren<Letter>().isSelectable = false;
                parent.transform.GetChild(i).GetComponentInChildren<Letter>().isFirstTime = false;
            }
            // Addes the selected letter to the word list
            theGridManager.addText(gameObject.GetComponentInChildren<Text>().text);
        }
        // Activates when user deselect the tile 
        else if(isSelected)
        {
            // Does the same as the selection but vice versa
            isSelected = !isSelected;
            gameObject.GetComponentInChildren<Text>().color = Color.white;
            
            theGridManager.removeText(gameObject.GetComponentInChildren<Text>().text);
        }  
        // Activates when user selects the tile next times
        else if(isSelectable && !isSelected && !isFirstTime)
        {
            isSelected = !isSelected;
            gameObject.GetComponentInChildren<Text>().color = Color.red;
            theGridManager.addText(gameObject.GetComponentInChildren<Text>().text);
        }

        // Allow user to activate only adjacent buttons (Better to change in the future)
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            if(parent.transform.GetChild(i).GetComponentInChildren<Letter>().isSelected == true)
            {  
                if (i == 0) 
                {
                    parent.transform.GetChild(i + 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i + 10).GetComponentInChildren<Letter>().changeSelected();
                }
                else if(i == 59)
                {
                    parent.transform.GetChild(i - 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i -10 ).GetComponentInChildren<Letter>().changeSelected();
                }
                else if(i >= 50)
                {
                    parent.transform.GetChild(i + 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i - 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i -10 ).GetComponentInChildren<Letter>().changeSelected();
                }
                else if(i > 10)
                {
                    parent.transform.GetChild(i + 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i - 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i + 10).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i - 10 ).GetComponentInChildren<Letter>().changeSelected();
                }
                else if (i > 0)
                {
                    parent.transform.GetChild(i + 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i - 1).GetComponentInChildren<Letter>().changeSelected();
                    parent.transform.GetChild(i + 10).GetComponentInChildren<Letter>().changeSelected();
                }  
            }
        }
        
    }

   
    // Function to change if a button is Selectable 
    public void changeSelected()
    {
        isSelectable = !isSelectable;
    }
}
