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
            // Campfire
            new CraftRecipe(12, new int[]
            {
                0, 0, 0,
                0, 1, 0,
                11, 11, 11
            }),
            // Axe
            new CraftRecipe(7, new int[]
            {
                0,1,11,
                0,1,0,
                0,1,0
            }),
            // Fishing Pole
            new CraftRecipe(8, new int[]
            {
                0,0,13,
                0,1,0,
                1,0,0
            }),
            // Bucket
            new CraftRecipe(10, new int[]
            {
                0,0,0,
                14,0,14,
                14,14,14
            })
        };
    }
}
