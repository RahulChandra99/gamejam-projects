using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button myButton;
    public Text txt;  
    public string playerSide;

    private GameManagerVSCOMP myController;

    void Start()
    {
        myButton = GetComponent<Button>();
        txt = GetComponentInChildren<Text>();

    }

    public void SetSpace()
    {
        txt.text = myController.GetPlayerSide();
        myButton.interactable = false;
        myController.EndTurn();
    }

    public void SetController(GameManagerVSCOMP controller)
    {
        myController = controller;
    }

}
