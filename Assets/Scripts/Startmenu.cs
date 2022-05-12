using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Startmenu : MonoBehaviour
{

    private float time;  //변수 time

    // Start is called before the first frame update
    void Start()
    {

        time = 0; // time 초기화


    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;   //time이 늘어남

        if(time > 5)
        {
            SceneManager.LoadScene("Popo_Rebuilding");  //일정 시간이 지나면 time이 로드됨
            // 스타트씬과엔드씬을 키를누르면 바뀌게 바꾸는걸 계획  (이 코드는 시간이지나면 바뀜)

        }


    }
}
