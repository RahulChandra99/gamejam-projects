using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace MazeCollapse
{
    public class LevelScreenManager : MonoBehaviour
    {
        

       public void PlayGame()
        {
            SceneManager.LoadSceneAsync("GameScene");

            if (EventSystem.current.currentSelectedGameObject.name == "Level1_btn")
            {
                PlayerPrefs.SetInt("LevelNo", 1);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "Level2_btn")
            {
                PlayerPrefs.SetInt("LevelNo", 2);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "Level3_btn")
            {
                PlayerPrefs.SetInt("LevelNo", 3);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "Level4_btn")
            {
                PlayerPrefs.SetInt("LevelNo", 4);

            }
        }

        public void buttonSound()
        {

            SoundManager.Instance.ButtonSound();
        }

        public void musicToggle()
        {
            SoundManager.Instance.MusicToggle();
        }

        public void SoundToggle()
        {
            SoundManager.Instance.SFXToggle();
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene("GameScene");
            
        }
    }

}
