using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private Text textRecipe;
    [SerializeField] private TypeFruit typeFruit;

    private const float timeHide = 0.5f;
    private int number;

    public TypeFruit GetTypeFruit { get => typeFruit; }

    public void SetRecipeData(int countRecipe)
    {
        if (countRecipe <= 0)
        {
            if (gameObject.activeSelf)
            {
                HideRecipe();
            }
            else
            {
                return;
            }
        }

        if (gameObject.activeSelf && number != countRecipe)
        {
            StartCoroutine(CoRedraw(countRecipe));
        }
        else
        {
            textRecipe.text = countRecipe.ToString();

            gameObject.SetActive(true);
        }

        number = countRecipe;
    }

    public void HideRecipe()
    {
        StartCoroutine(CoHide());
    }

    private IEnumerator CoHide()
    {
        GetComponent<Animator>().SetTrigger(TypeAnimationPanel.Hide.ToString());
        yield return new WaitForSeconds(timeHide);
        gameObject.SetActive(false);
    }

    private IEnumerator CoRedraw(int count)
    {
        GetComponent<Animator>().SetTrigger(TypeAnimationPanel.Change.ToString());
        yield return new WaitForSeconds(timeHide);
        textRecipe.text = count.ToString();
    }
}
