using System.Collections;
using UnityEngine;

public class BlenderAnimation : MonoBehaviour
{
    [SerializeField] private GameObject blender;
    [SerializeField] private GameObject[] effectsDamageBlender;

    private Animator animator;
    private bool right;
    private bool damage;

    public bool GetDamage { get => damage; }

    private void Start()
    {
        animator = blender.GetComponent<Animator>();
    }

    public void SwipeRight()
    {
        right = true;
    }

    public void SwipeLeft()
    {
        right = false;
    }

    public void StopSwipe()
    {
        if (right)
        {
            animator.SetTrigger("StopSwipeRight");
        }
        else
        {
            animator.SetTrigger("StopSwipeLeft");
        }
    }

    public void Work()
    {
        damage = false;
        animator.SetTrigger("Work");

        StartCoroutine(CoShowDamagerEffects(false));
    }

    public void CutFruit()
    {
        animator.SetTrigger("Cut");
    }

    public void FreezeBlender()
    {
        animator.SetTrigger("Freeze");
    }

    public void EffectDamageBlender()
    {
        damage = true;
        animator.SetTrigger("Damage");

        StartCoroutine(CoShowDamagerEffects(true));
    }

    private IEnumerator CoShowDamagerEffects(bool show)
    {
        yield return new WaitForSeconds(.25f);

        foreach (var effect in effectsDamageBlender)
        {
            effect.SetActive(show);
        }
    }
}
