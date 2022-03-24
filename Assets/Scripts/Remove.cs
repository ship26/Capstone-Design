using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    private float deadtime;
    private float flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {

        deadtime += Time.deltaTime;

        if(deadtime > 1000*flag)
        {
            Destroy(gameObject);
        }

    }
}
