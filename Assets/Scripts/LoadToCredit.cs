using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * script explanation
 * shows Earth image and fade out  
 * after fade out effect, load EndingCredit Scene 
 */

public class LoadToCredit : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("EndingCredit");
        FadeEffect();
    }

    private IEnumerator FadeEffect()
    {
        float fadeCount = 0; //initial alpha value

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f; //lower alpha value 0.01 per 0.01 second 
            yield return new WaitForSeconds(0.01f); //per 0.01 second
            image.color = new Color(0, 0, 0, fadeCount); //makes image look transparent  
        }
        //after while loop ends, load EndingCredit scene
        SceneManager.LoadScene("EndingCredit");
    }

    // Update is called once per frame
    void Update()
    {
        //FadeEffect();
        //SceneManager.LoadScene("EndingCredit");
    }
}
