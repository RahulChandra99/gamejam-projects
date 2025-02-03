using UnityEngine;
using UnityEngine.UI;

namespace MazeCollapse
{
    /*-------------MANAGE THE AUDIO PART OF THE GAME
                          ATTACHED TO SOUND MANAGER GAME OBJECT------------------*/

    public class SoundManager : MonoBehaviour
    {

        //singleton design pattern implementation
        #region Singleton

        //Singleton Implementation


        public static SoundManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }



        #endregion

        private AudioSource BGMusic;

        [Header("SFX")]
        public AudioSource buttonClickSound;

        public Button MusicButton;
        public Button SFXButton;

        public Sprite disabledMusicSprite;
        public Sprite enabledMusicSprite;

        public Sprite enabledEffectsSprite;
        public Sprite disabledEffectsSprite;


        private void Start()
        {
            BGMusic = GetComponent<AudioSource>();
            
        }

        private void Update()
        {
            MusicButton = GameObject.FindGameObjectWithTag("Music").GetComponent<Button>();
            SFXButton = GameObject.FindGameObjectWithTag("SFX").GetComponent<Button>();
        }

        public void MusicToggle()
        {
            if (BGMusic.mute)
            {
                BGMusic.mute = false;
                MusicButton.image.sprite = enabledMusicSprite;
            }
            else if (!BGMusic.mute)
            {
                BGMusic.mute = true;
                MusicButton.image.sprite = disabledMusicSprite;
            }

        }

        public void SFXToggle()
        {
            if (buttonClickSound.mute)
            {
                buttonClickSound.mute = false;
                SFXButton.image.sprite = enabledEffectsSprite;
            }
            else if (!buttonClickSound.mute)
            {
                buttonClickSound.mute = true;
                SFXButton.image.sprite = disabledEffectsSprite;
            }
                
        }

        public void ButtonSound()
        {
            buttonClickSound.Play();
        }

    }
}


