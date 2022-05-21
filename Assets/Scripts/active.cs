using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{

    private float time;
    public GameObject et;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Excute());

        time = 0;


    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        //Debug.Log(time);
        
        Run();


    }


    void Run()
    {
        if (time > 300)
        {

            et.SetActive(true);


        }


    }


/*
    IEnumerator Excute()
    {


        yield return new WaitForSeconds(5.0f);

        gameObject.SetActive(true);


    }*/



}
