using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text crossText;
    public Text nougatText;
    public Text drawText;

    private void Start()
    {
        if(GameManager.flag == true)
            StoreScore();

        GameManager.flag = false;
    }
    void StoreScore()
    {
        crossText.text = "" + GameManager.crossScore;
        nougatText.text = "" + GameManager.nougatScore;
        drawText.text = "" + GameManager.drawScore;
    }
}
