using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("ModeMenu");
    }

    public void SettingsBtn()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void TwoPModeBtn()
    {
        SceneManager.LoadScene("2P_3x3");
    }

    public void Back2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Back2ModeMenu()
    {
        SceneManager.LoadScene("ModeMenu");
    }

    public void TwoP_3X3Restart()
    {
        SceneManager.LoadScene("2P_3x3");
    }

    public void VSMode_3x3Restart()
    {
        SceneManager.LoadScene("2P_VSComp");
    }

    public void VSMode_3x3ModeBtn()
    {
        SceneManager.LoadScene("2P_VSComp");
    }
}
