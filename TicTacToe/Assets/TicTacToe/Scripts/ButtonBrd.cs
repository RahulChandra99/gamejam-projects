using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBrd : MonoBehaviour
{
    public int squareNumber = 0;

    private void OnMouseDown()
    {
        GameObject.Find("GameManager").SendMessage("SquareClicked", gameObject);
        Destroy(this);
    }
}
