using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacierDestroy2 : MonoBehaviour
{

    AudioSource audiosource;
    private Animator am;

    // Start is called before the first frame update
    void Start()
    {

        audiosource = GetComponent<AudioSource>();
        am = GetComponent<Animator>();
        StartCoroutine(DestroyS());
        StartCoroutine(Destroy());
        StartCoroutine(Destroy2());



    }

    // Update is called once per frame
    void Update()
    {



    }



    IEnumerator DestroyS()
    {

        yield return new WaitForSeconds(50.0f);

        audiosource.Play();




    }

    IEnumerator Destroy()
    {

        yield return new WaitForSeconds(60.0f);

        am.SetBool("isDestroy", true);

    }

    IEnumerator Destroy2()
    {

        yield return new WaitForSeconds(71.5f);

        Destroy(gameObject);

    }




}