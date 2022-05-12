using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineDestroy : MonoBehaviour
{

    public float deadtime = 30.0f;
    float hp = 1000.0f;



    private void OnCollisionStay(Collision col)
    {


        if (col.gameObject.tag == "Player")
        {

            Destroy(gameObject);

        }


    }







    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        hp -= deadtime * Time.deltaTime;


        if (hp <= 0)
            Destroy(gameObject);


    }

  







}
