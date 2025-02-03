using UnityEngine;
using UnityEngine.UI;

namespace fb
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets instance;

        public bool isAngryBirdGameStarted = false;
        public bool isFlappyBirdGameStarted = false;

        public Text[] _inGameTextStorage;

        public Transform pipeHead;
        public Transform pipeBody;

        public GameObject coinPrefab;
        public static GameAssets GetInstance()              //this script can be accessed from anyother script because of static 
        
        {   //we can access the public fields from here through other scripts
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {

        }
    }
}

