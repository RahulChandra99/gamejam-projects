using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace fb
{


    public class LevelManager : MonoBehaviour
    {
        private const float pipeBody_width = 8f;
        private const float pipeHead_height = 3.75f;
        private const float Camera_Orthographic_size = 50f;
        [SerializeField] private float pipeMoveSpeed = 25f;
        private const float Destroy_X_position = -100f;
        private const float SpawnPipe_X_position = 300f;
        private static LevelManager instance;
        public Text[] mytext;



        public static LevelManager GetInstance()
        {
            return instance;
        }


        private float spawnTimer;
        private float spawnTimeMax;
        private float gapSize;
        private List<Pipe> pipesList;

        [SerializeField] private int pipesSpawned;
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard,
            Impossible
        }


        private void Awake()
        {
            instance = this;
            pipesList = new List<Pipe>();
            spawnTimeMax = 1f;
            SetDifficulty(Difficulty.Easy);
        }


        private void Update()
        {


            if (GameAssets.GetInstance().isFlappyBirdGameStarted)
            {
                HandlePipeMovement();
                HandlePipeSpawning();
            }

        }


        private void SetDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    gapSize = Random.Range(20f, 60f);
                    spawnTimeMax = Random.Range(1.5f, 2.2f);
                    break;
                case Difficulty.Medium:
                    gapSize = 40f;
                    spawnTimeMax = 1.1f;
                    break;
                case Difficulty.Hard:
                    gapSize = 30f;
                    spawnTimeMax = 1f;
                    break;
                case Difficulty.Impossible:
                    gapSize = 20f;
                    spawnTimeMax = 0.9f;
                    break;
            }
        }
        private Difficulty CurrentDifficulty()
        {


            if (pipesSpawned >= 80) return Difficulty.Impossible;
            if (pipesSpawned >= 50) return Difficulty.Hard;
            if (pipesSpawned >= 30) return Difficulty.Medium;
            return Difficulty.Easy;


        }

        private void HandlePipeSpawning()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                //spawn the pipes
                spawnTimer += spawnTimeMax;

                float heightEdgeLimit = 10f;
                float minHeight = gapSize * 0.5f + heightEdgeLimit;
                float totalHeight = Camera_Orthographic_size * 2f;
                float maxHeight = totalHeight - gapSize * 0.5f - heightEdgeLimit;

                float heigt = UnityEngine.Random.Range(minHeight, maxHeight);


                CreateGapPipes(heigt, gapSize, SpawnPipe_X_position);
                pipeMoveSpeed += 5F;
            }
        }
        private void HandlePipeMovement()
        {
            for (int i = 0; i < pipesList.Count; i++)
            {

                Pipe pipe = pipesList[i];
                //cycling through all the pipes

                pipe.Move(pipeMoveSpeed);

                if (pipe.getXPosititon() < Destroy_X_position)
                {
                    pipe.DestroyPipes();
                    pipesList.Remove(pipe);
                    i--;
                }

            }


        }

        void CreateGapPipes(float gapY, float gapSize, float xPosition)
        {
            CreatePipes(gapY - gapSize * .5f, xPosition, true);


            CreatePipes(Camera_Orthographic_size * 2f - gapY - gapSize * 0.5f, xPosition, false);
            pipesSpawned++;
            if (pipesSpawned > 5)
            {
                PlayerController.GetInstance().myText.gameObject.SetActive(false);
                mytext[0].gameObject.SetActive(true);
            }

            if (pipesSpawned > 8)
            {
                mytext[0].gameObject.SetActive(false);
                mytext[1].gameObject.SetActive(true);
            }
            if (pipesSpawned > 13)
            {
                mytext[1].gameObject.SetActive(false);
                mytext[2].gameObject.SetActive(true);
            }
            if (pipesSpawned > 20)
            {
                ToNextLevel();
            }
            SetDifficulty(CurrentDifficulty());


        }

        private void CreatePipes(float height, float xPosition, bool spawnBottom)
        {
            Transform pipeHd = Instantiate(GameAssets.GetInstance().pipeHead);

            float YheadPosition;
            if (spawnBottom)                                                    //TO SPAWN ON TOP OR BOTTOM CONDITION
            {
                YheadPosition = -Camera_Orthographic_size + height - pipeHead_height * 0.5f;
            }
            else
                YheadPosition = -(-Camera_Orthographic_size + height - (pipeHead_height * 0.5f));

            pipeHd.position = new Vector2(xPosition, YheadPosition);             //TO SET THE X AND Y POSITION OF PIPE HEAD



            Transform pipeBd = Instantiate(GameAssets.GetInstance().pipeBody);

            float YBodyPosition;
            if (spawnBottom)                                                //TO SPAWN ON TOP OR BOTTOM CONDITION
            {
                YBodyPosition = -Camera_Orthographic_size;
            }
            else
            {
                YBodyPosition = Camera_Orthographic_size;
                pipeBd.localScale = new Vector3(1, -1, 1);
            }

            pipeBd.position = new Vector2(xPosition, YBodyPosition);        //TO SET THE X AND Y POSITION OF THE PIPE BODY
            SpriteRenderer pbSR = pipeBd.GetComponent<SpriteRenderer>();
            pbSR.size = new Vector2(pipeBody_width, height);            //TO SET THE HEIGHT OF THE PIPE BODY



            BoxCollider2D pipeBodyBoxCollider2d = pipeBd.GetComponent<BoxCollider2D>();
            pipeBodyBoxCollider2d.size = new Vector2(pipeBody_width, height);
            pipeBodyBoxCollider2d.offset = new Vector2(0f, height * 0.5f);

            Pipe pipe = new Pipe(pipeHd, pipeBd);
            pipesList.Add(pipe);
        }

        public int GetPipesSpawned()
        {
            return pipesSpawned;
        }



        /*for single pipe */
        private class Pipe
        {
            private Transform pipeHeadTransform;
            private Transform pipeBodyTransform;

            public Pipe(Transform pipeHeadTransform, Transform pipeBodyTransform)
            {
                this.pipeBodyTransform = pipeBodyTransform;
                this.pipeHeadTransform = pipeHeadTransform;
            }

            public void Move(float movementSpeed)
            {
                pipeHeadTransform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
                pipeBodyTransform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;

            }

            public float getXPosititon()
            {
                return pipeHeadTransform.position.x;
            }

            public void DestroyPipes()
            {

                Destroy(pipeHeadTransform.gameObject);
                Destroy(pipeBodyTransform.gameObject);

            }
        }

        void ToNextLevel()
        {
            Debug.Log("this");
            pipeMoveSpeed += 20f;
            spawnTimeMax = 8f;
            gapSize = 50f;
            FadeToRedScript.GetInstance().StartFadeToRed();
            FadeToRedScript.GetInstance().StartFadeToRed();
            SceneManager.LoadSceneAsync("GameScene_VerticalRunner");


        }





    }


}

