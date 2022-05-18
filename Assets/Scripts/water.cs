using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class water : MonoBehaviour
{
    public Material fog_mat;
    public Color fogColor;
    public float fog_depthStart = -12;
    public float fog_depthDistance = 98;

    public Material underwater_mat;

    [Range(0.001f, 0.1f)]
    public float pixelOffset = 0.02f;
    [Range(0.1f, 20f)]
    public float noiseScale = 1f;
    [Range(0.1f, 20f)]
    public float noiseFrequency = 2.2f;
    [Range(0.1f, 30f)]
    public float noiseSpeed = 3.8f;

    public float underwater_depthStart = 1;
    public float underwater_depthDistance = 120;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "water")   //물안에 객체가 잇으면
        {
            GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;

            fog_effect(fog_mat);
            OnRenderImage1(null, Camera.main.targetTexture); //source를 뭘로 써야 할 지...?
            underwater_effect(underwater_mat);
            OnRenderImage2(null, Camera.main.targetTexture); //source를 뭘로 써야 할 지...?
        }
    }

    public void fog_effect(Material mat)
    {
        mat.SetColor("_FogColor", fogColor);
        mat.SetFloat("Fog_DepthStart", fog_depthStart);
        mat.SetFloat("Fog_DepthDistance", fog_depthDistance);
        //포그 효과 
    }

    public void underwater_effect(Material mat)
    {
        mat.SetFloat("_PixelOffset", pixelOffset);
        mat.SetFloat("_NoiseScale", noiseScale);
        mat.SetFloat("_NoiseFrequency", noiseFrequency);
        mat.SetFloat("_NoiseSpeed", noiseSpeed);
        mat.SetFloat("UnderWater_DepthStart", underwater_depthStart);
        mat.SetFloat("UnderWater_DepthDistance", underwater_depthDistance);
        //언더워터 효과
    }

    public void OnRenderImage1(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, fog_mat);
    }

    public void OnRenderImage2(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, underwater_mat);
    }
}
