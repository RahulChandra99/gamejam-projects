using Cinemachine;
using UnityEngine;


namespace fb
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {


            GameAssets.GetInstance()._inGameTextStorage[0].gameObject.SetActive(true);
        }

        private void Start()
        {

            GameAssets.GetInstance().isAngryBirdGameStarted = true;
        }
    }
}

