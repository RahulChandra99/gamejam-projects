using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fb
{
    public class RepeatBG : MonoBehaviour
    {
        private Rigidbody2D rb;
        private BoxCollider2D boxCollider;

        [SerializeField] float width;
        public float speed = 12f;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();

            width = boxCollider.size.x;
           
        }

        private void Update()
        {
             if (GameAssets.GetInstance().isFlappyBirdGameStarted)
                rb.velocity = new Vector2(-speed, 0);
                
            if (transform.position.x < -width/2)
            {
                Reposition();
            }
        }

        void Reposition()
        {
            Vector2 vector = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
    }
}

