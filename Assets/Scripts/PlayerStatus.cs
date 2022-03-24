using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject gmo;
    public GameObject Feed;
    public float deadtime = 30.0f;
    float hp = 1000.0f;
    float breath = 100f;


    public PostProcessProfile ppf;
    DepthOfField dof;



    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "water")
        {

            breath -= deadtime * Time.deltaTime;

        }
    }


    private void OnCollisionStay(Collision col)
    {


        if (col.gameObject.tag == "Feed")
        {

            hp += 5000;

        }


    }

    private void OnTriggerExit(Collider coll)
    {
        breath = 100;
    }

    private void OnColliderEnter(Collider coll)
    {


        if (coll.gameObject.tag == "Feed")
        {
            hp += 20;

            Destroy(Feed);

        }

    }
    void Start()
    {
        
        ppf = gmo.GetComponent<PostProcessVolume>().profile;
        ppf.TryGetSettings<DepthOfField>(out dof);
        dof.enabled.value = true;


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(hp);

        hp -= deadtime * Time.deltaTime;


        if (hp >= 100)
        {
            dof.aperture.value = 10.0f;
           
            
        }
        else if(hp <=50 && hp >=10)
        {
            dof.aperture.value = 0.75f;
        }
        else if( hp<=10 && hp>0)
        {
            dof.aperture.value = 0.05f;
        }
        else if ( hp <= 0)
        {
            Destroy(Player);
        }
       
          
            
        

      




        if (breath >= 50.0f)
        {

            dof.focusDistance.value = 10.0f;
        }
        else if (breath >= 10.0f && breath < 50.0f)
        {

            dof.focusDistance.value = 2.0f;
        }
        else if (breath < 10.0f && breath >0.0f)
        {

            dof.focusDistance.value = 0.1f;
        }
        else if (breath <= 0.0f)
        {
            Destroy(Player);
        }



    }



    private T static_cast<T>(float deltaTime)
    {
        throw new NotImplementedException();
    }
}

