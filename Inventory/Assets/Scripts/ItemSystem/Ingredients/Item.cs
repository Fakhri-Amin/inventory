using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HerbalDrinkMaker
{

    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemSO itemSO;
        [SerializeField] private int stackSize;

        public Item(ItemSO itemSO)
        {
            this.itemSO = itemSO;
            AddToStack();
        }


        public void AddToStack()
        {
            stackSize++;
        }

        public ItemSO GetIngredientSO() => itemSO;
        public int GetStackSize() => stackSize;
    }
}
