using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HerbalDrinkMaker
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;

        [SerializeField] private InventorySlotUI[] inventorySlotUIArray;
        [SerializeField] private GameObject inventorySlotPrefab;

        private void Awake()
        {
            Instance = this;
        }

        public bool TryAddItem(ItemSO itemSO)
        {
            // Check if any slot has the same item with stack count lower than max
            for (int i = 0; i < inventorySlotUIArray.Length; i++)
            {
                InventorySlotUI slot = inventorySlotUIArray[i];
                InventoryItemUI itemInSlot = slot.GetComponentInChildren<InventoryItemUI>();
                if (itemInSlot != null && itemInSlot.itemSO == itemSO && itemInSlot.stackCount < itemInSlot.itemSO.stackMaxCount && itemInSlot.itemSO.isStackable == true)
                {
                    itemInSlot.stackCount++;
                    itemInSlot.UpdateStackCountUI();
                    return true;
                }
            }

            // Find any empty slot
            for (int i = 0; i < inventorySlotUIArray.Length; i++)
            {
                InventorySlotUI slot = inventorySlotUIArray[i];
                InventoryItemUI itemInSlot = slot.GetComponentInChildren<InventoryItemUI>();
                if (itemInSlot == null)
                {
                    SpawnNewItem(itemSO, slot);
                    return true;
                }
            }
            return false;
        }

        private void SpawnNewItem(ItemSO itemSO, InventorySlotUI slot)
        {
            GameObject newItem = Instantiate(inventorySlotPrefab, slot.transform);
            InventoryItemUI inventoryItemUI = newItem.GetComponent<InventoryItemUI>();
            inventoryItemUI.InitilizeItem(itemSO);
        }
    }
}
