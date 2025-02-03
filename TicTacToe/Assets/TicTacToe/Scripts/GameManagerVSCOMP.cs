 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerVSCOMP : MonoBehaviour
{

    public Text TurnText;
    

    public Text winningText;

    public Text[] buttonList;
    private string playerSide;

    private int clickCount;

   

    private void Awake()
    {
        playerSide = "X";
        SetControllerOnButton();
        clickCount = 0;
        
    }
    void SetControllerOnButton()
    {
        for(int i =0;i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetController(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        clickCount++;

        //Top Row   
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        //Middle Row   
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        //Bottom Row   
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        //Left Column  
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        //Middle Column   
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        //Right Column  
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        //Left-Right dig  
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        //Right-Left dig 
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (clickCount >= 9)
        {
            winningText.text = "Draw!";
        }

        //ChangeTurnText();
        else
        {
            ChangeSides();
            if (playerSide == "O")
            {
                ComputerTurn();
            }
        }
        

        
    }

    void GameOver()
    {
        for(int i = 0;i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        winningText.text = playerSide + "  wins ";
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void ChangeTurnText()
    {
        if (playerSide == "X")
            TurnText.text = "O";
        else if (playerSide == "O")
            TurnText.text = "X";
    }

    void ComputerTurn()
    {

        bool foundEmptySpot = false;
        
        while (!foundEmptySpot)
        {

            int RandomNumber = Random.Range(0, 9);

            if (buttonList[RandomNumber].GetComponentInParent<Button>().IsInteractable())
            {

                buttonList[RandomNumber].GetComponentInParent<Button>().onClick.Invoke();
                foundEmptySpot = true;

            }
        }
    }

   
}
