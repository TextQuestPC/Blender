using System.Collections;
using UnityEngine;

public class EffectSlicing : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleObject;
    [SerializeField] private ParticleSystem particleObject2;
    [SerializeField] private Material materialParticle;
    [SerializeField] private Texture2D green;
    [SerializeField] private Texture2D yellow;
    [SerializeField] private Texture2D orange;
    [SerializeField] private Texture2D red;

    [SerializeField] private float timeEffect;

    private ParticleSystem.MainModule particle;
    private ParticleSystem.MainModule particle2;

    private GameObject effect;

    private void Awake()
    {
        particle = particleObject.main;
        particle2 = particleObject2.main;
    }

    public void ShowSliceFruit(Fruit fruit)
    {
        materialParticle.mainTexture = green;

        if (fruit.GetTypeColor == TypeColor.Green)
        {
            materialParticle.mainTexture = green;
        }
        else if (fruit.GetTypeColor == TypeColor.Yellow)
        {
            materialParticle.mainTexture = yellow;
        }
        else if (fruit.GetTypeColor == TypeColor.Orange)
        {
            materialParticle.mainTexture = orange;
        }

        else if (fruit.GetTypeColor == TypeColor.Red)
        {
            materialParticle.mainTexture = red;
        }

        if (particleObject.gameObject.activeSelf)
        {
            StartCoroutine(CoShowEffect(particleObject2.gameObject));
        }
        else
        {
            StartCoroutine(CoShowEffect(particleObject.gameObject));
        }

    }

    private IEnumerator CoShowEffect(GameObject effect)
    {
        effect.SetActive(true);
        yield return new WaitForSeconds(timeEffect);
        effect.SetActive(false);
    }
}
