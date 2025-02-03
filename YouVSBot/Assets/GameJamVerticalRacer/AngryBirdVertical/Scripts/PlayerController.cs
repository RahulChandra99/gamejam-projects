using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace fb
{
    public class PlayerController : MonoBehaviour
    {
        /*Variables*/

        private Rigidbody2D birdRB;
        private TrajectoryLine trajectoryLine;
        private Camera cam;
        private Vector3 initialPos;

        //public int scoreCount = 0;

        private static PlayerController instance;

        public static PlayerController GetInstance()
        {
            return instance;
        }
        // [Header("Game Activation booleans")]
        //public bool angryBirdControlactive = false;
        //  public bool flappyBirdControlactive = false;

        [Header("DragToShoot variables")]
        public float launchPower = 10f;
        public Vector2 minPower;
        public Vector2 maxPower;
        public Transform TrajectoryStartPos;
        private Vector3 startPos;
        private Vector3 endPos;
        private Vector2 force;

        [Header("JumpInPlace variables")]
        public float jumpForce = 100f;


        public Text myText;

        /*Unity Methods*/

        private void Awake()
        {
            instance = this;
            birdRB = GetComponent<Rigidbody2D>();
            trajectoryLine = GetComponent<TrajectoryLine>();
            birdRB.gravityScale = 0;
            initialPos = transform.position;
        }

        private void Start()
        {
            cam = Camera.main;

        }
        private void Update()
        {

            ApplyAngryBirdControls();
            ApplyFlappyBirdControls();
        }




        /*Callback Functions*/




        private void ApplyAngryBirdControls()
        {
            if (GameAssets.GetInstance().isAngryBirdGameStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                    startPos.z = 15;

                }

                if (Input.GetMouseButton(0))
                {
                    Vector3 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
                    currentPos.z = 15;
                    trajectoryLine.RenderLine(startPos, currentPos);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    endPos = cam.ScreenToWorldPoint(Input.mousePosition);
                    endPos.z = 15;

                    force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
                    birdRB.velocity = force * launchPower;
                    birdRB.gravityScale = 10;

                    trajectoryLine.EndLine();



                }
            }
        }

        private void ApplyFlappyBirdControls()
        {
            if (GameAssets.GetInstance().isFlappyBirdGameStarted)
            {
                GameAssets.GetInstance().isAngryBirdGameStarted = false;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //disabling follow camera when player starts jumping 
                    Camera.main.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
                    birdRB.velocity = Vector2.up * jumpForce;

                }
            }

        }

        void Death()
        {
            //death screen
            SceneManager.LoadSceneAsync("GameScene");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Collectable"))
            {
                //scoreCount++;
                //disable the coin sprite
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("pipe"))
            {
                Debug.Log("dead");
                Death();
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("FbStarted"))
            {
                //activating the flappy bird pipes spawn
                GameAssets.GetInstance().isFlappyBirdGameStarted = true;

                //deactivate : "Will you launch it already"
                GameAssets.GetInstance()._inGameTextStorage[0].gameObject.SetActive(false);

                birdRB.gravityScale = 35;
                myText.gameObject.SetActive(true);
            }

        }
    }



}
