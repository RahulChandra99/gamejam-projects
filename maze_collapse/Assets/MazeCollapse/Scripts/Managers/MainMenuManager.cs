using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeCollapse
{
                                                                                    /* -------- MANAGE THE MAIN MENU  ---------------*/

    public class MainMenuManager : MonoBehaviour
    {
        [Header("Character Prefabs")]
        public GameObject[] characters;
        public int selectedChar = 0;


        public void NextBtn()
        {
            characters[selectedChar].SetActive(false);
            selectedChar++;


            if (selectedChar > characters.Length - 1)
                selectedChar = 0;

            characters[selectedChar].SetActive(true);
        }

        public void PrevBtn()
        {
            characters[selectedChar].SetActive(false);
            selectedChar--;


            if (selectedChar < 0)
                selectedChar = characters.Length - 1;

            characters[selectedChar].SetActive(true);
        }

        public void PlayGame()
        {
            //saving the character choice using player prefs
            PlayerPrefs.SetInt("charChoosen", selectedChar);
            
            SceneManager.LoadSceneAsync("LevelSelectionScreen");
        }
    }
}

