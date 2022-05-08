using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * 스크립트 설명:
 * 씬에서 캐릭터가 죽고 나면(카메라 효과로 죽는 거 몇 초 동안 이펙트 보여줌)
 * fade out 으로 화면 검은색으로 변하고 오프닝 씬(지구)으로 넘어감 
 */

public class LoadToOpening : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*private IEnumerator FadeEffect()
    {
        float fadeCount = 0; //처음 알파값

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f; //투명도를 0.01씩 올리면서 
            yield return new WaitForSeconds(0.01f); //0.01초마다 실행
            image.color = new Color(0, 0, 0, fadeCount); //fadeCount를 알파값으로 지정해서 화면이 검은색에서 점점 투명해진다 
        }
        //while문을 빠져나온다 >> fade out 완료되면 엔딩크레딧씬 부름
        //SceneManager.LoadScene("EndingCredit");
    }
    */

    void Update()
    {
        
    }
}
