using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    #region Variables
    // Public variables
    // Parent object of all letters
    public GameObject parent;
    // Words that user should find
    public GameObject words;
    // The text which user has chosen
    public string addedText;
    // List of words user should find(In the future may be added through a text file document)  
    List<string> listStrings = new List<string>(); 
 
    // Private variables
    bool _isChangeble;
    char[] wordsChar;
    string _wordsString;
    int _currCountLast;
    #endregion

    
    void addWordsToList()
    {
        // List of words user should find(In the future may be added through a text file document)  
        listStrings.Add("ARBUZ");
        listStrings.Add("TOPOVIY");
        listStrings.Add("CHEL");
        
        // Check to not to create a words in the end of the table
        for(int i = 0; i < listStrings.Count; i++)
        {
            int tempCountlast = listStrings[i].Length;
            if(_currCountLast < tempCountlast)
                _currCountLast = tempCountlast;              
        }
        
       
    }
    // Start is called before the first frame update
    void Start()
    {   
        // Call addWordsToList function
        addWordsToList();

        // Instantiate all words into GUI 
        for(int i = 0; i < words.transform.childCount; i++)
        {
            words.transform.GetChild(i).GetComponentInChildren<Text>().text = listStrings[i];
        }

        // Instantiate randomly all letters into GUI 
        for(int i = 0; i < parent.transform.childCount; i++)
        {   
            char randomChar = (char)('A' + Random.Range (0,26));
            parent.transform.GetChild(i).GetComponentInChildren<Text>().text = randomChar.ToString();
        }

        // Instantiate all nedded to find words into the table of letters
        for(int i = 0; i < listStrings.Count; i++)
        {
            // Find a random place to start adding words
            int _rand = Random.Range(0, parent.transform.childCount - _currCountLast);
            
            // Find the length of the words
            wordsChar = listStrings[i].ToCharArray();
            _wordsString = new string(wordsChar);
            
            // Add words to the table
            for(int y = 0; y < _wordsString.Length; y++)
            {   
                parent.transform.GetChild(_rand + y).GetComponentInChildren<Text>().text = _wordsString[y].ToString(); 
            }
        }
    }
    private void Update()
    {
        // Check if a user found the words, if yes color them to red
        if(listStrings.Contains(addedText))
        {
            
            for(int i = 0; i < words.transform.childCount; i++)
            {
                if(words.transform.GetChild(i).GetComponentInChildren<Text>().text == addedText)
                {
                    words.transform.GetChild(i).GetComponentInChildren<Text>().color = Color.red;
                } 

            }
            Reset();
        }
    }

    // Resets everything 
    public void Reset()
    {
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).GetComponentInChildren<Letter>().isSelectable = true;
            parent.transform.GetChild(i).GetComponentInChildren<Letter>().isFirstTime = true;
            parent.transform.GetChild(i).GetComponentInChildren<Letter>().isSelected = false;
            parent.transform.GetChild(i).GetComponentInChildren<Text>().color = Color.white;
        }
        addedText = string.Empty;

    }

    // Function to add active letters to the whole text
    public void addText(string text)
    {
        addedText += text;
        Debug.Log(addedText);
    }
    // Function to remove active letters to the whole text
    public void removeText(string text)
    {
        
        addedText = addedText.Replace(text, string.Empty); 
        Debug.Log(addedText);
    }




}
