using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterGenerate : MonoBehaviour
{

    AudioSource audiosource;
    private float time;
    public GameObject prefabs;  //생산할 게임오브젝트 넣을 변수
    // Start is called before the first frame update
    private BoxCollider area;   // 박스 콜라이더의 사이즈를 가져옴
    private List<GameObject> gameObject = new List<GameObject>();  //생성할 오브젝트 담을 리스트


    void Start()
    {

        audiosource = GetComponent<AudioSource>();
        area = GetComponent<BoxCollider>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        
        Gen();

    }

    private void Gen()
    {

        if (time >60)
        {
            time = 0;
            audiosource.Play();
            Act();


        }




    }

    private void Act()
    {
        for (int i = 0; i < 2; ++i)    //생성수많큼 생성한다
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

        selectedPrefab.active = true;




        Vector3 spawnPos = GetRandomPosition();  //랜덤위치 

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);  //오브젝트 복제

        gameObject.Add(instance);  //game오브젝트 맵에 추가 (생성)






    }

}
