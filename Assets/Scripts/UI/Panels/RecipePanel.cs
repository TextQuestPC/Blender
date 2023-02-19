using UnityEngine;

public class RecipePanel : MonoBehaviour
{
    [SerializeField] private RecipeUI[] recipesUI;

    public void ShowRecipe(DataNeedFruit dataNeedFruit)
    {
        foreach (var dataNeed in dataNeedFruit.GetPartsNeedFruits)
        {
            foreach (var recipe in recipesUI)
            {
                if (recipe.GetTypeFruit == dataNeed.GetTypeFruit)
                {
                    recipe.SetRecipeData(dataNeed.GetCountFruit);
                }
            }
        }
    }
}
