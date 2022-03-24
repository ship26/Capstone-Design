using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefabs;  //생산할 게임오브젝트 넣을 변수

    private BoxCollider area;   // 박스 콜라이더의 사이즈를 가져옴


   

    public int count = 5;   //생산할  먹이 수 

    private List<GameObject> gameObject = new List<GameObject>();
    // Start is called before the first frame update



    void Start()
    {


        area = GetComponent<BoxCollider>();

        for(int i = 0; i< count; ++i)
        {

            Spawn1();

            area.enabled = false;
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private Vector3 GetRandomPosition()
    {

        Vector3 basePosition = transform.position;
        Vector3 size = area.size;


        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;




    }

    private void Spawn1()
    {

       

        GameObject selectedPrefab = prefabs;
        selectedPrefab.transform.localScale = new Vector3(5, 5, 5);
       

        


        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        gameObject.Add(instance);






    }




}
