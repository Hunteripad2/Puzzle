using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    [HideInInspector] protected Inventory inventoryObject;
    [HideInInspector] protected LogText logText;

    [Header("Interaction")]
    [SerializeField] protected GameObject objectToInteract;
    [SerializeField] public float interactionRadius = 1.5f;
    [SerializeField] public InventoryItem.ItemId requiredItemId;

    [Header("Notifications")]
    [SerializeField] protected string noItemText = "I can't do this...";
    [SerializeField] protected string wrongItemText = "I don't think it's helpful...";
    [SerializeField] public string analyzeText;

    [Header("Sound Effects")]
    [SerializeField] protected AudioSource interactionSoundEffect;
    [SerializeField] protected AudioSource wrongItemSoundEffect;

    virtual public void Start()
    {
        inventoryObject = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        logText = GameObject.FindGameObjectWithTag("Log").GetComponent<LogText>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    virtual public void Interact(InventoryItem usedItem)
    {
        print("No Interaction Found");
    }

    protected bool CheckUsedItem(InventoryItem usedItem)
    {
        if (requiredItemId != InventoryItem.ItemId.none && usedItem?.itemId != requiredItemId)
        {
            if (usedItem == null)
            {
                logText.SetText(noItemText);
            }
            else
            {
                logText.SetText(wrongItemText);
            }
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Analyze()
    {
        logText.SetText(analyzeText);
    }
}
