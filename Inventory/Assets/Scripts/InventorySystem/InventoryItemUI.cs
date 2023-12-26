using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

namespace HerbalDrinkMaker
{
    public class InventoryItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private TMP_Text stackCountText;
        [HideInInspector] public ItemSO itemSO { get; private set; }
        [HideInInspector] public Transform parentAfterDrag;
        private Image image;
        private CanvasGroup canvasGroup;
        private Vector3 initialLocalScale;
        private Camera mainCamera;
        private bool isOverUI;

        public int stackCount { get; set; } = 1;

        private void Awake()
        {
            image = GetComponent<Image>();
            canvasGroup = GetComponent<CanvasGroup>();
            mainCamera = Camera.main;
        }

        private void Start()
        {
            initialLocalScale = transform.localScale;
        }

        public void InitilizeItem(ItemSO itemSO)
        {
            this.itemSO = itemSO;
            image.sprite = itemSO.sprite;
            UpdateStackCountUI();
        }

        public void UpdateStackCountUI()
        {
            stackCountText.text = "x" + stackCount;
            bool textActive = stackCount > 1;
            stackCountText.gameObject.SetActive(textActive);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            image.raycastTarget = false;
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = GameInput.Instance.GetMousePosition();
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            this.isOverUI = isOverUI;
            if (isOverUI)
            {
                canvasGroup.alpha = 0.6f;
                transform.localScale = initialLocalScale;
                stackCountText.gameObject.SetActive(true);
            }
            else
            {
                stackCountText.gameObject.SetActive(false);
                canvasGroup.alpha = 1f;
                transform.localScale = Vector3.one * 1.4f;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            image.raycastTarget = true;
            canvasGroup.alpha = 1f;
            // transform.localScale = initialLocalScale;
            if (isOverUI)
            {
                transform.SetParent(parentAfterDrag);
            }
            else
            {
                Vector3 mousePosition = GameInput.Instance.GetMousePosition();
                mousePosition.z = 10;
                Vector3 spawnedPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                Instantiate(itemSO.prefab, spawnedPosition, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
