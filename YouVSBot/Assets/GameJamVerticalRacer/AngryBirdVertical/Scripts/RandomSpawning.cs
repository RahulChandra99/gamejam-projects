using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fb
{
    public class RandomSpawning : MonoBehaviour
    {
        public GameObject[] pipePrefabs;
        public Transform[] spawnPositions;
        private int index1;
        private int index2;
        private Vector3 yPosition;
        public float respawnTime;

        private void Start()
        {
            yPosition = new Vector3(0f, 0f, 0f);
            StartCoroutine(StartWave());
        }

        IEnumerator StartWave()
        {
            while (true)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnenemy();
            }

        }


        void spawnenemy()
        {
            index1 = Random.Range(0, spawnPositions.Length);

            for (int i = 0; i < spawnPositions.Length; i++)
            {
                index2 = Random.Range(0, pipePrefabs.Length);
                GameObject pipe = Instantiate(pipePrefabs[index2]) as GameObject;
                pipe.transform.position = spawnPositions[index1].position + yPosition;
                yPosition.y += 40f;
            }
            


            //pipe.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,Random.Range(0f,180f));


        }
    }

}
