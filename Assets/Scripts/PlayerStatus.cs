using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;   //player 오브젝트
    public GameObject gmo;      
    public GameObject Feed;    //물고기오브젝트 등록
    public float deadtime = 30.0f;  //deadtime 수치 이걸곱해서 수치조절
    float hp = 1000.0f;   //에너지 수치  시간이지나면줄어들고 물고기를먹으면 차는형식
    float breath = 100f;  //숨수치  물안에들어가면 시간이지나면 줄어들고 물밖에 나오면 차는 형식
    public Material waterMaterial;
    public Material originMaterial;

    private Color originColor;       
    private float originFogDestiny;   //물안에서 시야를바꾸는 fog를 이용한 방법중하나로 넣어본것 



    public PostProcessProfile ppf;   //시야를 조절하는 변수
    DepthOfField dof;



    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "water")   //물안에 객체가 잇으면
        {




           // RenderSettings.skybox = waterMaterial;  물안에서 시야를 바꾸는 skybox작업처리임 어색해서 주석처리했음 물안에서 시야처리를 하는 한가지 방벙빌 수 있음! 물안에 들어갈경우 시야의 skybox를 물색으로 변해서 물안의 느낌을 받게함 쉐이더를 조절하면 그럴싸할지도.

          // breath -= deadtime * Time.deltaTime;   테스트를 위해서 일부로 주석처리함  - breath가 시간마다 deadtime과 곱해져서 breath수치가 줄어듬



        }




    }


    private void OnCollisionStay(Collision col)
    {


        if (col.gameObject.tag == "Feed")   //feed라는 태그를 단  오브젝트(먹이) 와 충돌시 hp를 회복한다
        {

            hp += 5000;

        }


    }

    private void OnTriggerExit(Collider coll)
    {
        
        if (coll.gameObject.tag == "water")  //물밖에 나올경우 숨게이지를 회복한다
        {
            breath = 100;    //

           // RenderSettings.skybox = originMaterial;   나올경우 시야의 skybox를 원래되로 돌린다

        }


    }

    private void OnColliderEnter(Collider coll)
    {


        if (coll.gameObject.tag == "Feed")   //feed라는 태그를 단  오브젝트(먹이) 와 충돌시 hp를 회복한다 그리고 먹이를 제거한다
        {
            hp += 20;

            Destroy(Feed);

        }

    }
    void Start()
    {
        
        ppf = gmo.GetComponent<PostProcessVolume>().profile;
        ppf.TryGetSettings<DepthOfField>(out dof);  //postprocessing 시야 요소를 받는다
        dof.enabled.value = true;


       
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(hp);   //hp수치를 로그에 띄워서 보여준다 이것도 테스트를위해넣음

        //hp -= deadtime * Time.deltaTime;    //시간이 지나면 hp가감소한다 테스트를 위하여 잠시 주석처리함


        if (hp >= 100)
        {
            dof.aperture.value = 10.0f;     //에너지에따라서 postprocessing 의 dof를 조절하여 시야를 조절한다
           
            
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
       
          
            
        

      




        if (breath >= 50.0f)           //숨에따라서 postprocessing 의 dof를 조절하여 시야를 조절한다
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
            //Destroy(Player);
        }



    }



    private T static_cast<T>(float deltaTime)
    {
        throw new NotImplementedException();
    }
}

