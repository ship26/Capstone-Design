using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove3 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {



        StartCoroutine(Destroy());



    }

    // Update is called once per frame
    void Update()
    {



    }




    IEnumerator Destroy()
    {


        yield return new WaitForSeconds(180.0f);

        Destroy(gameObject);

    }





}