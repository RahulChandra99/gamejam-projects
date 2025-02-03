using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Taking the prefab of cross and circle
    public GameObject cross;                
    public GameObject circle;

    
    //turn tells us whos turn it is , 1 = cross 2 = circle
    int turn = 1;
   public int winner = 0;

    public int[] squares = new int[9];

    //winner display text
    public Text winnerdisplaytxt;

   public int clickCount = 0;

    //text fir turn text
    public Text turnText;

    public static int crossScore = 0;
    public static int nougatScore = 0;
    public static int drawScore = 0;

    public static bool flag = false;

    public void SquareClicked(GameObject square)
    {
        //Get the square number
        int squareNumber = square.GetComponent<ButtonBrd>().squareNumber;

        clickCount++;

        //spawn the prefab on square click
        SpawnPrefab(square.transform.position);

        //Make the player choose the square
        squares[squareNumber] = turn;

        CheckForWinner();
        
        NextTurn();

        TurnImage();

        
    }



    void CheckForWinner()
    {

        for(int player = 1; player <=2; player++)
        {
             //top row
            if(squares[0] == player && squares[1]== player && squares[2]== player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;
            }

            //middle row
            if (squares[3] == player && squares[4] == player && squares[5] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //last row
            if (squares[6] == player && squares[7] == player && squares[8] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //left coln
            if (squares[0] == player && squares[3] == player && squares[6] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //middle coln
            if (squares[1] == player && squares[4] == player && squares[7] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //right coln
            if (squares[2] == player && squares[5] == player && squares[8] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //left-right diagonal
            if (squares[0] == player && squares[4] == player && squares[8] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }

            //right-left diagonal
            if (squares[2] == player && squares[4] == player && squares[6] == player)
            {
                DisableSquares();
                print(player + " wins");
                winner = player;

            }
        }

        //check for draw
        if(clickCount == 9 && winner == 0)
        {
            winner = 3;
        }
        

    }
    void SpawnPrefab(Vector2 position)
    {
        if (turn == 1)
            Instantiate(cross, position, Quaternion.identity);

        else if (turn == 2)
            Instantiate(circle, position, Quaternion.identity);
    }

    void NextTurn()
    {
        turn += 1;

        if (turn == 3)
            turn = 1;
    }

    private void OnGUI()
    {
        if(winner == 1)
        {
            //winner is cross
            crossScore++;
            winnerdisplaytxt.text = "X  Wins";
            winnerdisplaytxt.color = new Color(1f, 0f, 0f);
            flag = true;
            
        }
        else if(winner == 2)
        {
            //winner is nougat
            nougatScore++;
            winnerdisplaytxt.text = "O  Wins";
            winnerdisplaytxt.color = new Color(1f, 0f, 0f);
            flag = true;
        }

        else if(winner == 3)
        {
            //draw
            
            winnerdisplaytxt.text = "Draw!";
            winnerdisplaytxt.color = new Color(1f, 0f, 0f);
            drawScore++;
            flag = true;
        }
    }

    void DisableSquares()   
    {
        //destroy the remaining sqaures
        foreach(ButtonBrd square in GameObject.FindObjectsOfType<ButtonBrd>())
        {
            Destroy(square);
        }
    }

    void TurnImage()
    {
        if(turn == 1)
        {
            turnText.text = "X";
        }

        else if(turn ==2)
        {
            turnText.text = "O";
        }
    }
}
