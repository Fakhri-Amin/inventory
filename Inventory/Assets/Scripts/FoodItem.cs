using System.Collections;
using System.Collections.Generic;
using HerbalDrinkMaker;
using UnityEngine;

public class FoodItem : InteractableBase
{
    [SerializeField] private FoodItemSO foodItemSO;

    public override void Interact()
    {
        InventoryManager.Instance.TryAddItem(foodItemSO);
    }
}
