using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl_Ham : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float moveSpeed = 10f;
    public float rotateSpeed = 180f;
    private int jumppower = 300;

    private bool isstone = true;
    private PlayerInput PlayerInput;
    private Animator animator;
    private bool isground = true;
    private int jumpcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
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

    private void Move()
    {

        Vector3 moveDistance = PlayerInput.move * -transform.right * moveSpeed * Time.deltaTime;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (jumpcount == 1)
            {

                animator.SetBool("JumpStart", true); //점프하기 전에 애니메이션 넣기
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

    }
}
