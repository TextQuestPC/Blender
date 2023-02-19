using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Frost")]
public class FrostEffect : MonoBehaviour
{
    public float FrostAmount = 0.5f; //0-1 (0=minimum Frost, 1=maximum frost)
    public float EdgeSharpness = 1; //>=1
    public float minFrost = 0; //0-1
    public float maxFrost = 1; //0-1
    public float seethroughness = 0.2f; //blends between 2 ways of applying the frost effect: 0=normal blend mode, 1="overlay" blend mode
    public float distortion = 0.1f; //how much the original image is distorted through the frost (value depends on normal map)
    public Texture2D Frost; //RGBA
    public Texture2D FrostNormals; //normalmap
    public Shader Shader; //ImageBlendEffect.shader

    private Material material;

    private bool action = false;
    private bool showFrost = false;
    private float stepAmount = 1f;
    private float minValueFrost = 0f;
    private float maxValueFrost = 0.4f;

    private void Awake()
    {
        material = new Material(Shader);
        material.SetTexture("_BlendTex", Frost);
        material.SetTexture("_BumpMap", FrostNormals);
    }

    private void Update()
    {
        if (action)
        {
            if (showFrost)
            {
                ShowFrost();
            }
            else
            {
                HideFrost();
            }
        }
    }

    private void ShowFrost()
    {
        FrostAmount += stepAmount * Time.deltaTime;

        if(FrostAmount>= maxValueFrost)
        {
            FrostAmount = maxValueFrost;
            action = false;
        }
    }

    private void HideFrost()
    {
        FrostAmount -= stepAmount * Time.deltaTime;

        if (FrostAmount <= minValueFrost)
        {
            FrostAmount = minValueFrost;
            action = false;
            this.enabled = false;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!Application.isPlaying)
        {
            material.SetTexture("_BlendTex", Frost);
            material.SetTexture("_BumpMap", FrostNormals);
            EdgeSharpness = Mathf.Max(1, EdgeSharpness);
        }
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(FrostAmount) * (maxFrost - minFrost) + minFrost));
        material.SetFloat("_EdgeSharpness", EdgeSharpness);
        material.SetFloat("_SeeThroughness", seethroughness);
        material.SetFloat("_Distortion", distortion);

        Graphics.Blit(source, destination, material);
    }

    public void FrostScreen()
    {
        action = true;
        showFrost = true;
    }

    public void UnFrostScreen()
    {
        action = true;
        showFrost = false;
    }
}