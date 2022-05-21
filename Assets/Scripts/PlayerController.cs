using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody PlayerRigidbody;  //playerRigidbody
    public float moveSpeed = 10f;   //움직임속도
    public float rotateSpeed = 180f;  //회전속도
    private int jumppower = 10;  //점프파워
    private int waterjumppower = 4; //물속 점프파워
    private PlayerInput playerInput;  //PlayerInput 스크립트
    private Animator animator;  //애니메이터
    private bool isground = true;  //불린값  땅에있는가?
    private bool iswater = false;  //불린값 물에있는가?
    private int jumpcount = 1;    //점프카운트

 
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();   //요소들을 불러옴
        PlayerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

       

    }
    private void FixedUpdate()
    {

        Rotate();

        Move();

        Jump();



    

     


       
            
    }

 


    private void Move()
    {
        //캐릭터 이동 함수
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        PlayerRigidbody.MovePosition(PlayerRigidbody.position + moveDistance);  //playerinput의 축에 값을 곱해서 캐릭터를 움직임
        

    }

    private void Rotate()
    {
        //캐릭터 회전 함수
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;

        PlayerRigidbody.rotation = PlayerRigidbody.rotation * Quaternion.Euler(0, turn, 0f); //playerinput의 축에 값을 곱해서 캐릭터를 회전함


    }

    private void Jump()
    {

        //캐릭터 점프 홤수

        if(Input.GetButton("Jump"))
        {

            
            if (isground ==true && jumpcount == 1)  //땅에있고 점프카운트가 1일때
            {
                
                PlayerRigidbody.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
          
                isground = false;  //isground값을 false로
                jumpcount = 0;  //점프카운트 0으로
              

            }

            if (iswater ==true )
            {


                    PlayerRigidbody.AddForce(Vector3.up * waterjumppower, ForceMode.Impulse);  //물안일경우 캐릭터를 위로 움직임(점프카운트제한없이)
                    
              


            }

           
        }

    }

    private void OnCollisionEnter(Collision col)
    {
       

        if(col.gameObject.tag == "ground")    //만약 객체가 '땅'속성을 가진 오브젝트와 닿을시
        {

            Physics.gravity = new Vector3(0, -19.81f, 0); //중력 원상복귀

            isground = true;  //isground(조건문)을 true로
            jumpcount = 1;  //점프카운트 복귀
        }
       

    }

    private void OnTriggerStay(Collider coll)  //물에 닿아있는 경우
    {
        if (coll.gameObject.tag == "water")
        {
            Physics.gravity = new Vector3(0, -20.0f, 0);  //중력 낮춤

           
            iswater = true;
            animator.SetBool("iswater", true);   //iswater 값을 true 함


           



        }
    }

    private void OnTriggerExit(Collider coll)  //물에서 나올 경우
    {
        if (coll.gameObject.tag == "water")
        {


            Debug.Log("--");
            iswater = false;
            animator.SetBool("iswater", false);  //물에서 나올 경우 iswater 값을 false함

            PlayerRigidbody.velocity = Vector3.zero;   //물에서 나오면 속력값 초기화하고 빙하에 도달할 점프만큼 점프시킴

            PlayerRigidbody.AddForce(Vector3.up * 4*jumppower, ForceMode.Impulse);  //이수치를 조절하여 점프크기조절





        }

    }


    void Update()
    {

        if (playerInput.move >= 0.1)   //전진키를 누를경우 애니메이션 전진, 후진키를 누를경우 애니메이션 후진
        { 
            animator.SetBool("isforward", true);
        }
        else
        {
            animator.SetBool("isforward", false);
        }

        if( playerInput.move <= -0.1)
        {
            animator.SetBool("isbackward", true);
        }
        else
        {
            animator.SetBool("isbackward", false);
        }
       


    }






}
