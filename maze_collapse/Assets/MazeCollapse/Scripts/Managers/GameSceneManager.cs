using MazeCollapse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeCollapse
{
                                                                          /* --------------------------- ATTACHED TO UI GAME OBJECT -------------------------*/

    public class GameSceneManager : MonoBehaviour
    {
        // to manage the sound part of the scene

        public void MusicToggle()
        {
            SoundManager.Instance.MusicToggle();
        }

        public void BtnSound()
        {
            SoundManager.Instance.ButtonSound();
        }

        public void SfxTog()
        {
            SoundManager.Instance.SFXToggle();
        }
    }

}
