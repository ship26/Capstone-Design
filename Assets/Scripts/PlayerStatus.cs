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
    public float deadtime = 60.0f;
    float hp = 10000.0f;
    float breath = 100f;
  
    
    public PostProcessProfile ppf;
    public DepthOfField dof;


    void Start()
    {
       
        ppf = gmo.GetComponent<PostProcessVolume>().profile;
        ppf.TryGetSettings<DepthOfField>(out dof);
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "water")
        {

            breath -= deadtime * Time.deltaTime;

        }
    }

    private void OnTriggerExit(Collider coll)
    {
        breath = 100;
    }





    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W))



        


        hp -= deadtime*Time.deltaTime;


        if (hp >= 50)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 10.0f;


        }
        if (hp >= 10 && hp < 50)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 2.0f;

        }
        if (hp < 10)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 0.1f;

        }

     

        if (hp <= 0)
        {

            Destroy(Player);


        }

        if(breath >= 50)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 10.0f;
        }
        if(breath >= 10 && breath < 50)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 2.0f;
        }
        if(breath < 10)
        {
            dof.enabled.value = true;
            dof.focusDistance.value = 0.1f;
        }

        if(breath <= 0)
        {
            Destroy(Player);
        }



    }






    private T static_cast<T>(float deltaTime)
    {
        throw new NotImplementedException();
    }
}

