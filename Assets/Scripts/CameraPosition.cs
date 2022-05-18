using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FogEffect; //FogEffect 클래스를 사용함
using static UnderWaterEffect; //UnderWater 클래스를 사용함

public class CameraPosition : MonoBehaviour
{

    public GameObject player;     //GameObject 플레이어
    private PlayerInput playerinput;  //player input 스크립트 
    public static bool is_underwater = false; //물 속에 있는지 체크하는 부울 변수 
    public FogEffect fe = new FogEffect(); //FogEffect를 참조하기 위한 변수 생성
    public UnderWaterEffect u_water = new UnderWaterEffect(); //UnderWaterEffect를 생성하기 위한 변수 생성

    // Start is called before the first frame update
    void Start()
    {

        transform.position = player.transform.position;  //player의 위치를 읽어 온다.
        transform.Translate(new Vector3(6f,5.5f,-3f));   //적절한 위치로 카메라를 옮긴다.

    }

    // Update is called once per frame
    void Update()
    {

        CameraTurn();
        transform.Rotate(0, 0, 0);




    }


    private void CameraTurn()
    {
        //player가 회전할때 카메라의 위치를 수정한다.
        if (player.transform.eulerAngles.y >= 270 && player.transform.eulerAngles.y <= 360)
        {
            transform.position = player.transform.position + new Vector3(-player.transform.eulerAngles.y / 400, 6.6f, -400 / player.transform.eulerAngles.y); 
            transform.Translate(new Vector3(1.2f, -0.8f, 7.6f));
        }

    }


 
}
