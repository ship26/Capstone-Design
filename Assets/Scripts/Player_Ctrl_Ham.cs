using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl_Ham : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    private int jumppower = 300;

    private bool isstone = true;
    private PlayerInput PlayerInput;
    private Animator animator;
    private bool isground = true;
    private int jumpcount = 0;
    public bool isbush = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        PlayerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        jumpcount = 1;


    }

    private void FixedUpdate()
    {

        Rotate();

        Move();




        
        if (isground)
        {
            jumpcount = 1;

            Jump();
        }


    }

    private void Move()
    {

        Vector3 moveDistance = PlayerInput.move * transform.forward * 3 * Time.deltaTime;

        PlayerRigidbody.MovePosition(PlayerRigidbody.position + moveDistance);


    }

    private void Rotate()
    {

        float turn = PlayerInput.rotate * rotateSpeed * Time.deltaTime;

        PlayerRigidbody.rotation = PlayerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);


    }

    private void Jump()
    {


        //점프 부분도 애니메이션이 있는데 랜딩이랑 점프 애니메이션 모델로 확인해보고 넣기
        if (Input.GetButtonDown("Jump"))
        {
            
            if (jumpcount == 1)
            {
              
                PlayerRigidbody.AddForce(Vector3.up * jumppower, ForceMode.Force);
                isground = false;
                jumpcount = 0;

                

               
            }

            

        }
      

       







    }

    //고릴라 에셋에 애니메이션이 다 포함되어 있고 attack도 있어요 
    // Update is called once per frame


   void Update()
    {
        


        if (PlayerInput.move >= 0.1)   //전진키를 누를경우 애니메이션 전진, 후진키를 누를경우 애니메이션 후진
        {
            animator.SetBool("Walkforward", true);
        }
        else
        {
            animator.SetBool("Walkforward", false);
        }

        if (PlayerInput.move <= -0.1)
        {
            animator.SetBool("WalkBack", true);
        }
        else
        {
            animator.SetBool("WalkBack", false);
        }

        
        if (transform.position.y <-5)
        {
            Destroy(gameObject);
        }




    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "bush")
        {
            isbush = true;



        }
    }

    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "ground")    //만약 객체가 '땅'속성을 가진 오브젝트와 닿을시
        {
            
            Physics.gravity = new Vector3(0, -9.81f, 0); //중력 원상복귀
            
            isground = true;  //isground(조건문)을 true로
            jumpcount = 1;  //점프카운트 복귀
        }


    }

   


    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "bush")
        {

            isbush = false;
        }

    }
}
