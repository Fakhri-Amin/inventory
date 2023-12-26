using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField] private GameObject interactionIndicatorIcon;
    protected bool isInteractable;

    protected GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void Start()
    {
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
        interactionIndicatorIcon.SetActive(false);
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (isInteractable) Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionIndicatorIcon.SetActive(true);
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionIndicatorIcon.SetActive(false);
            isInteractable = false;
        }
    }

    public abstract void Interact();

}
