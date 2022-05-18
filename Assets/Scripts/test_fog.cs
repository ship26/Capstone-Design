using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class test_fog : MonoBehaviour
{
    [SerializeField] private float waterDrag; // 물 속 저항력
    private float originDrag; // 물 밖 세상의 원래 저항력
    public Material _mat; 
    public Color fogColor;
    public float depthStart = -12;
    public float depthDistance = 98;
    [SerializeField] private GameObject thePlayer;
    private Color originColor; // 물 밖 세상의 낮의 원래 Fog 색깔

    // Start is called before the first frame update
    void Start()
    {
        originColor = RenderSettings.fogColor;

        originDrag = thePlayer.GetComponent<Rigidbody>().drag;
    }

    // Update is called once per frame
    void Update()
    {
        _mat.SetColor("_FogColor", fogColor);
        _mat.SetFloat("_DepthStart", depthStart);
        _mat.SetFloat("_DepthDistance", depthDistance);
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _mat);
    }
}
