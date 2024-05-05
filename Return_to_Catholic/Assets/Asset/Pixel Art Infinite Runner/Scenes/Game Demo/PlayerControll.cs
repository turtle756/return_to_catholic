
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour {

    // 물리 관련 변수
    public Rigidbody2D PlayerRigidbody; // 플레이어의 Rigidbody2D
    public int forcejump; // 점프에 필요한 힘
    public Animator anime; // 애니메이션 컨트롤러

    // 땅에 닿는지 확인하는 변수
    public Transform GroundCheck; // 땅 확인 위치
    public bool grounded; // 플레이어가 땅에 닿아있는지 여부
    public LayerMask WhatIsGround; // 땅 레이어

    // 게임 오버 상태
    public static bool gameOver;

    // 터치 상태 변수
    public bool touch; // 터치 입력이 활성화되었는지 여부
    public bool touchUp; // 터치 입력이 해제되었는지 여부
    public bool nottouch; // 터치 입력이 없는 상태인지 여부

    // 점프 상태
    public bool jump;
    //public bool gameoverEND;

    // 시간 변수
    public float jumpTempo; // 점프 지속 시간
    public float slideTempo; // 슬라이드 지속 시간
    private float timeTempo; // 점프 시간 카운터
    private float timeTempo2; // 슬라이드 시간 카운터

    // 생명
    public int maxvida = 3; // 최대 생명
    public static int quantvida; // 현재 생명

    // 코인 변수 (미사용)
    public static int moeda;

    // 스와이프 관련 변수
    private float fingerStartTime = 0.0f; // 터치 시작 시간
    private Vector2 fingerStartPos = Vector2.zero; // 터치 시작 위치
    public bool isSwipe = false; // 스와이프가 활성화되었는지 여부
    private float minSwipeDist = 50.0f; // 최소 스와이프 거리
    private float maxSwipeTime = 0.5f; // 최대 스와이프 시간

    // 슬라이드 충돌 위치
    public Transform colisor;

    // 오디오
    public AudioSource audioFont; // 오디오 소스
    public AudioClip soundJump; // 점프 소리


    // 초기화 함수
    void Start()
    {
        gameOver = false; // 게임 오버 상태 초기화
        quantvida = 0; // 현재 생명 초기화
    }

    // Update is called once per frame
    void Update () {


//---------------------------------------------------------------------------------------------------------------------------------
		// 터치 시뮬레이션
		if (Input.GetMouseButtonUp (0)) {
			touchUp = true;
		}

		if (Input.GetMouseButton (0)) {
			touch = true;
			touchUp = false;
		}

        //-----------------------------------------------------------------------------------------------------------------------------





        //--------------------------------------------------------------------------------------------------


        //여기서 스크립트는 원을 만들고 캐릭터가 땅에 닿아 있는지 확인합니다. 0.1f는 원의 크기입니다.
        grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.1f, WhatIsGround);


        //캐릭터가 땅에 닿지 않을 때 애니메이터의 "점프"를 활성화합니다
        anime.SetBool ("jump", !grounded);
		anime.SetBool ("gameover", gameOver);

//------------------------- MOUSE CONTROLLS ------------------------------------------------------------------------------------------------------------------

		// 마우스 컨트롤로 점프
		if (Input.GetMouseButtonUp (0)) {
			if (grounded == true && jump == false) {
														
				PlayerRigidbody.AddForce (new Vector2 (0, forcejump)); // 점프 힘 추가
                audioFont.volume = 0.3f; // 오디오 볼륨 설정
				audioFont.PlayOneShot (soundJump); // 점프 소리 재생
				jump = true; // 점프 상태 설정
            }
			
		}

		//** SLIDE **-------------------------------------------------
		

//--------------------------------------------------------------------------------------------------------------------------------------------------


//----------------- TOUCH CONTROLLS---------------------------------------------------------------------------------------------------------------------------------
		// 터치 컨트롤로 점프 및 슬라이드
		if (Input.touchCount > 0 && jump == false){
			foreach (Touch touch in Input.touches){
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* 새로운 터치 시작h */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled :
					/* 터치가 취소됨 */
					isSwipe = false;
					break;


				case TouchPhase.Ended :

				
					// 터치가 끝남
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// 수평 스와이프
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// 수직 스와이프
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}

						// 좌우 스와이프 *****************************************************
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								// 오른쪽 이동
								
								Debug.Log("right");
								
							}else{
								// 왼쪽 이동
								Debug.Log("left");
								
							}
						}
						//******************************************************************************



					
						//swipe up and down *************************************
						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
								// 위로 이동
								Debug.Log("up");
								
							}else{
								//---------SLIDE-----------
								



							}
						}
						//***********************************************************
						//-----------------------




					}else {
						
						/////-----JUMP-----------------------------------------------------

						if (grounded == true && jump == false){
												
							PlayerRigidbody.AddForce(new Vector2(0, forcejump)); // 점프 힘 추가
                            audioFont.volume = 0.3f; // 오디오 볼륨 설정
							audioFont.PlayOneShot (soundJump); // 점프 소리 재생
							jump = true; // 점프 상태 설정
						}
					}
					//------------------
					break;
				}
			}
		}

        //-----------------------------------------------------------------------








        //--------------------TEMPO DO JUMP / TIME JUMP ----------------------------------------------------------------------
        // 점프 지속 시간 처리
        if (jump == true) {
			timeTempo += Time.deltaTime;
			if (timeTempo >= jumpTempo){
				if (grounded == true) {
					timeTempo = 0;
					jump = false;
				}
			}
		}
//--------------------------------------------------------------------------------------------------------------








//-------------------------------------------------------------------------------------------------------------------------------------


				

		   

//--------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP---------


		// ----------------JUMP---------------------------
		//se o botao for apertado
		//if (Input.GetButtonDown ("jump")) {

		/*

		if(Input.GetMouseButtonUp(0) && jump == false){
			
			// Se o mouse ou touch for apertado

			// se o mouse ou touch for "soltado"
			
			//if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			
			//se o personagem encostar no chao
			if (grounded == true){

				//se o personagem estiver fazendo slide
				if (slide == true){
					
					
					//sobe o box de colisao do slide
					colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.03f, colisor.position.z);
					
					//desliga o slide
					slide = false;
					
				}
				
				
				//faz player pular.
				
				
				PlayerRigidbody.AddForce(new Vector2(0, forcejump));
				
				jump = true;

			}

		}

		// -------------------------------------------------
		//Slide

		//if (Input.GetButtonDown ("slide") && grounded == true && slide == false) {
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && grounded == true && slide == false && jump == false) {

		
			//abaixa o box de colisao
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.05f, colisor.position.z);

			slide = true;

		}


*/
//--------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP-----------------------BACKUP---------




	}



    // 다른 충돌체와 접촉했을 때 호출되는 함수
    void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Object" )
		{
            gameOver = true; // 게임 오버 상태 설정
        }
	

	
	}
    // 게임 오버 상태를 처리하는 함수
    public void gameoverEND ()
    {
        SceneManager.LoadScene("Game Over"); // 게임 오버 씬 로드
    }
}