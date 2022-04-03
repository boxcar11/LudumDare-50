using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftRecipeDatabase : MonoBehaviour
{
    public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecipeDatabase();
    }

    public Item CheckRecipe(int[] recipe)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            if(craftRecipe.requiredItems.SequenceEqual(recipe))
            {
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }

    void BuildCraftRecipeDatabase()
    {
        recipes = new List<CraftRecipe>()
        {
            new CraftRecipe(12, new int[]
            {
                0, 0, 0,
                0, 1, 0,
                11, 11, 11
            })
        };
    }
}
