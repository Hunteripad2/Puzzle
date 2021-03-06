using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject_Collect : InteractableObject
{
    [HideInInspector] private Transform inventoryItemsFolder;
    [HideInInspector] private InventoryItem inventoryItem;

    override public void Start()
    {
        base.Start();
        inventoryItemsFolder = GameObject.FindGameObjectWithTag("Inventory Items Folder").transform;
        inventoryItem = GetComponent<InventoryItem>();
    }

    override public void Interact(InventoryItem usedItem)
    {
        if (!CheckUsedItem(usedItem))
        {
            player.wrongItemSoundEffect.Play();
            return;
        }

        interactionSoundEffect.Play();

        if (objectToInteract != null)
        {
            Destroy(objectToInteract);
        }

        GetComponent<BoxCollider>().enabled = false;
        inventoryUI.RemoveItem(usedItem);
        inventoryUI.AddItem(inventoryItem);
        transform.SetParent(inventoryItemsFolder);
    }
}
