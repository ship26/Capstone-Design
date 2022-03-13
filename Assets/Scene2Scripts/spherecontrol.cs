using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherecontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody PlayerRigidbody;
    public float moveSpeed = 10f;
    public float rotateSpeed = 180f;
    private int jumppower = 300;
    private PlayerInput playerInput;
    private bool isground = true;
   
    private int jumpcount = 1;


    public bool isbush = false;



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame


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



    void Update()
    {
        
    }

    private void Move()
    {

        Vector3 moveDistance = playerInput.move * -transform.right * moveSpeed * Time.deltaTime;

        PlayerRigidbody.MovePosition(PlayerRigidbody.position + moveDistance);


    }

    private void Rotate()
    {

        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;

        PlayerRigidbody.rotation = PlayerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);


    }

    private void Jump()
    {



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (jumpcount == 1)
            {
                PlayerRigidbody.AddForce(Vector3.up * jumppower, ForceMode.Force);
                isground = false;
                jumpcount = 0;



            }

        }

    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "bush")
        {

            isbush = true;

        }
    }

    private void OnTriggerExit(Collider coll)
    {

        
        isbush = false;
    }

}
