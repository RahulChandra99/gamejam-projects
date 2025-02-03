using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeCollapse
{
    public class GameManager : MonoBehaviour
    {

        

        #region Variables
        //region to declare variables


        public GameObject[] Levels;
       
        

        #endregion

        #region UnityMethods
        //region to declare the monobehaviour methods

        
        private void Start()
        {
            if (PlayerPrefs.GetInt("LevelNo") == 1)
            {
                Debug.Log("1");

                Levels[0].SetActive(true);
                Levels[1].SetActive(false);
                Levels[2].SetActive(false);
                Levels[3].SetActive(false);
            }

            if (PlayerPrefs.GetInt("LevelNo") == 2)
            {
                Debug.Log("2");

                Levels[0].SetActive(false);
                Levels[1].SetActive(true);
                Levels[2].SetActive(false);
                Levels[3].SetActive(false);
            }
            if (PlayerPrefs.GetInt("LevelNo") == 3)
            {
                Debug.Log("3");

                Levels[0].SetActive(false);
                Levels[1].SetActive(false);
                Levels[2].SetActive(true);
                Levels[3].SetActive(false);
            }
            if (PlayerPrefs.GetInt("LevelNo") == 4)
            {
                Debug.Log("4");

                Levels[0].SetActive(false);
                Levels[1].SetActive(false);
                Levels[2].SetActive(false);
                Levels[3].SetActive(true);
            }

        }

        private void Update()
        {
           
        }

        #endregion

        #region CallBackMethods
        //region to declare callback functions



        #endregion
    }
}

