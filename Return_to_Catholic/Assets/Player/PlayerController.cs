using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        // �÷��̾��� �ִ� ���� �ӵ�
        public float maxSpeed = 7;
        // ���� �� �ʱ� �ӵ�
        public float jumpTakeOffSpeed = 7;

        public bool gameOver = false; // ���� ���� ����
        bool jump;
        bool stopJump;

        // �ִϸ����� �� ���� ������Ʈ
        private Animator animator;
        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (!gameOver) // ���� ���� ���°� �ƴϸ� ��� ����
            {
                // ���� ���� ó��
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                }

                // ���� ���� ���°� �Ǹ� ��� �ִϸ��̼� ���
                if (gameOver)
                {
                    animator.SetTrigger("Char1_death");
                }

                UpdateJumpState();
            }
        }

        void UpdateJumpState()
        {
            if (jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpTakeOffSpeed);
                animator.SetTrigger("Char1_jump");
                jump = false;
                stopJump = false;
            }
            else if (stopJump && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // ���� ���� ���̱�
                stopJump = false;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // �� �Ǵ� ������ �浹 �� ���� ���� ���¸� true�� ����
            if (other.CompareTag("Enemy") || other.CompareTag("Trap"))
            {
                gameOver = true;
            }
        }
    }
}
