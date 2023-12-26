using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HerbalDrinkMaker
{
    public class AddRandomItemButtonUI : MonoBehaviour
    {
        [SerializeField] private ItemSO[] itemSOArray;

        public void AddRandomItem()
        {
            int randomNumber = Random.Range(0, itemSOArray.Length);
            if (InventoryManager.Instance.TryAddItem(itemSOArray[randomNumber]))
            {
                Debug.Log("Item Added");
            }
            else
            {
                Debug.Log("Item Failed to Add");
            }
        }
    }
}
