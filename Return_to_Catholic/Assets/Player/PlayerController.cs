using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        // 플레이어의 최대 수평 속도
        public float maxSpeed = 7;
        // 점프 시 초기 속도
        public float jumpTakeOffSpeed = 7;

        public bool gameOver = false; // 게임 오버 상태
        bool jump;
        bool stopJump;

        // 애니메이터 및 관련 컴포넌트
        private Animator animator;
        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (!gameOver) // 게임 오버 상태가 아니면 계속 진행
            {
                // 점프 상태 처리
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                }

                // 게임 오버 상태가 되면 사망 애니메이션 재생
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
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // 점프 높이 줄이기
                stopJump = false;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // 적 또는 함정에 충돌 시 게임 오버 상태를 true로 설정
            if (other.CompareTag("Enemy") || other.CompareTag("Trap"))
            {
                gameOver = true;
            }
        }
    }
}
