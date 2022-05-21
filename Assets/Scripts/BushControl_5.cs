using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BushControl_5 : MonoBehaviour
{
    AudioSource audiosource;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {


        audiosource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        StartCoroutine(Destroy1());
        StartCoroutine(Destroy2());

    }

    // Update is called once per frame
    void Update()
    {





    }


    IEnumerator Destroy1()
    {

        yield return new WaitForSeconds(300.0f);


        audiosource.Play();
        animator.SetBool("isdestroy", true);



    }

    IEnumerator Destroy2()
    {

        yield return new WaitForSeconds(305.5f);



        Destroy(gameObject);


    }


}
