using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeCollapse
{
                                                                /* --------------- manage the individual levels of the game ------------------*/

    public class LevelManager : MonoBehaviour
    {

        //Singleton Implementation
        #region Singleton




        public static LevelManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                
            }
        }



        #endregion

        #region Variables
        //region to declare variables


        public bool isKeyPicked;
        public bool isLockedUnLocked;
        public bool isBlueUnlocked;
        public bool isLevelEnded;

        public Transform parentObject; 

        [Tooltip("The number of tiles in the level excluding the blue end tile")]
        public int numberOfTiles;

        [Header("Character Prefabs")]
        public GameObject[] characters;

        [Header("Spawn Position of the Player in the level")]
        public Transform spawnPoint;


  

        #endregion

        #region UnityMethods
        //region to declare the monobehaviour methods

        private void Start()
        {

            var charSelected = PlayerPrefs.GetInt("charChoosen");
            GameObject prefab = characters[charSelected];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            clone.transform.SetParent(parentObject);
            


            //blue tiles collider is not present in the start
            GameObject.FindGameObjectWithTag("BlueEnd").GetComponent<BoxCollider>().enabled = false;
        }

        private void Update()
        {
            if (numberOfTiles == 0)
            {
                isBlueUnlocked = true;
                GameObject.FindGameObjectWithTag("BlueEnd").GetComponent<BoxCollider>().enabled = true;
            }


            if (isLevelEnded)
            {
                StartCoroutine("GoToLevelScreen");
            }

        }

        #endregion

        #region CallBackMethods
        //region to declare callback functions

        IEnumerator GoToLevelScreen()
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("LevelSelectionScreen");
        }

        #endregion
    }
}

