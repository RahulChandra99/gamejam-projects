using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace fb
{
    public class MainMenuManager : MonoBehaviour
    {


        public GameObject controlPanel;
        public GameObject creditsPanel;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public void CotrolBtn()
        {
            controlPanel.SetActive(true);

        }
        public void creditsBtn()
        {
            creditsPanel.SetActive(true);
        }

       public void PlayBtn()
        {
            StartCoroutine(WaitandLoadScene());
           audioSource.Stop();
           audioSource.PlayOneShot(audioClip);
        }

        IEnumerator WaitandLoadScene(){
            yield return new WaitForSeconds(7f);
            SceneManager.LoadSceneAsync("GameScene");
        }

        private void Update()
        {
            if (controlPanel.activeInHierarchy == true && (Input.GetKeyDown(KeyCode.Escape)))
            {
                controlPanel.SetActive(false);
            }
            if (creditsPanel.activeInHierarchy == true && (Input.GetKeyDown(KeyCode.Escape)))
            {
                creditsPanel.SetActive(false);
            }
        }

    }
}




