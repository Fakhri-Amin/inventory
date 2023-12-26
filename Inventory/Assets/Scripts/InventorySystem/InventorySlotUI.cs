using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HerbalDrinkMaker
{
    public class InventorySlotUI : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0)
            {
                InventoryItemUI inventoryItem = eventData.pointerDrag.GetComponent<InventoryItemUI>();
                inventoryItem.parentAfterDrag = transform;
            }
        }
    }
}
