using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefabs;  //생산할 게임오브젝트 넣을 변수

    private BoxCollider area;   // 박스 콜라이더의 사이즈를 가져옴


    private float spawntime = 300.0f; //스폰 시간
    private float spawnvalue = 30.0f;  

    public int count = 5;   //생산할  먹이 수 

    private List<GameObject> gameObject = new List<GameObject>();  //생성할 오브젝트 담을 리스트
    // Start is called before the first frame update



    void Start()
    {


        area = GetComponent<BoxCollider>();




        Act();



    }

    // Update is called once per frame
    void Update()
    {


        spawntime -= spawnvalue*Time.deltaTime;   //spawntime을 시간마다 줄이며 0이하가되면 다시 초기화시키면서 스폰함

        if ( spawntime <=0)
        {
            spawntime = 300.0f;
            Act();
        }






    }

    private void Act()
    {
        for (int i = 0; i < count; ++i)    //생성수많큼 생성한다
        {

            Spawn1();

            area.enabled = false;
        }



    }



    private Vector3 GetRandomPosition()    //오브젝트의 생성위치를 랜덤으로 잡아서 리턴하는 함수
    {

        Vector3 basePosition = transform.position;
        Vector3 size = area.size;


        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;




    }

    private void Spawn1()  //실제 생성 함수
    {

       

        GameObject selectedPrefab = prefabs;   //모델 선택
        selectedPrefab.transform.localScale = new Vector3(5, 5, 5);
       

        


        Vector3 spawnPos = GetRandomPosition();  //랜덤위치 

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);  //오브젝트 복제

        gameObject.Add(instance);  //game오브젝트 맵에 추가 (생성)






    }




}
