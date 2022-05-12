using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public string moveAxisName = "Vertical";  //이동의 축을 설정 
    public string rotateAxisName = "Horizontal";

    public float move { get; private set; }   //move와 rotate를 get 할수는 있고 설정은 못함
    public float rotate { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxis(moveAxisName);   //move는 앞뒤 rotate는 좌우(수평) 으로 키보드에서 키를 받아 값을 설정
        rotate = Input.GetAxis(rotateAxisName);


    }
}
