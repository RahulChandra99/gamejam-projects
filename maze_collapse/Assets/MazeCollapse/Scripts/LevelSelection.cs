using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace MazeCollapse
{
                                                                         /* ------------ATTACHED TO LEVEL DESIGN GAMEOBJECT --------------------*/

    public class LevelSelection : MonoBehaviour
    {

        [Tooltip("Stores the Levels Game objects in the array")]
        public GameObject[] Levels;

        public Camera cam;

        private void Start()
        {
            //deciding which level to be player using player prefs

            if (PlayerPrefs.GetInt("LevelNo") == 1)
            {
                Debug.Log("1");

                cam.backgroundColor = new Color32(76, 49, 121,0);

                Levels[0].SetActive(true);

                Levels[3].SetActive(false);
                Levels[1].SetActive(false);
                Levels[2].SetActive(false);
            }

            if (PlayerPrefs.GetInt("LevelNo") == 2)
            {
                Debug.Log("2");

                cam.backgroundColor = new Color32(69, 121, 49,0);
                Levels[1].SetActive(true);

                Levels[0].SetActive(false);
                Levels[3].SetActive(false);
                Levels[2].SetActive(false);
            }

            if (PlayerPrefs.GetInt("LevelNo") == 3)
            {
                Debug.Log("3");

                cam.backgroundColor = new Color32(129, 42, 72,0);
                Levels[2].SetActive(true);

                Levels[0].SetActive(false);
                Levels[1].SetActive(false);
                Levels[3].SetActive(false);
            }

            if (PlayerPrefs.GetInt("LevelNo") == 4)
            {
                Debug.Log("4");

                cam.backgroundColor = new Color32(50, 121, 87,0);
                Levels[3].SetActive(true);

                Levels[0].SetActive(false);
                Levels[1].SetActive(false);
                Levels[2].SetActive(false);
            }
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MM_CharSelect");
        }
    }
}

