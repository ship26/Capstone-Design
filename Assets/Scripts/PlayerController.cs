using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody PlayerRigidbody;
    public float moveSpeed = 10f;
    public float rotateSpeed = 180f;
    private int jumppower = 300;
    private int waterjumppower = 100;
    private PlayerInput playerInput;
    private Animator animator;
    private bool isground = true;
   
    private int jumpcount = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

       

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

    // Update is called once per frame


    private void Move()
    {

        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        PlayerRigidbody.MovePosition(PlayerRigidbody.position + moveDistance);
        

    }

    private void Rotate()
    {

        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;

        PlayerRigidbody.rotation = PlayerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);


    }

    private void Jump()
    {



        if(Input.GetKeyDown(KeyCode.Space))
        {
           
            if (jumpcount == 1)
            {
                PlayerRigidbody.AddForce(Vector3.up * jumppower, ForceMode.Force);
                isground = false;
                jumpcount = 0;

              

            }
           
        }

    }

    private void OnCollisionEnter(Collision col)
    {
       

        if(col.gameObject.tag == "ground")  
        {

            Physics.gravity = new Vector3(0, -9.81f, 0); //중력 원상복귀

            isground = true;
            jumpcount = 1;
        }
       

    }

    private void OnTriggerStay(Collider coll)  //물에 닿아있는 경우
    {
        if (coll.gameObject.tag == "water")
        {
            Physics.gravity = new Vector3(0, -3f, 0);  //중력 낮춤

            animator.SetBool("iswater", true);   //iswater 값을 true 함

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRigidbody.AddForce(Vector3.up * waterjumppower, ForceMode.Force);
            }



        }
    }

    private void OnTriggerExit(Collider coll)  //물에서 나올 경우
    {
        if (coll.gameObject.tag == "water")
        {
            animator.SetBool("iswater", false);  //물에서 나올 경우 iswater 값을 false함
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
