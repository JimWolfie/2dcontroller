using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    [SerializeField]private Inventory inventory = null;
    [SerializeField]private TextMeshProUGUI confirmText =null;

    private int slotIndex = 0;

    private void OnDisable()=> slotIndex =-1;

    public void Activate(ItemSlot itemSlot, int slotIndex)
    {
        this.slotIndex = slotIndex;
        confirmText.text = $"Would you Like to destroy {itemSlot.quantity}{itemSlot.item.name}? ";
        gameObject.SetActive(true);
    }
    public void Destroy()
    {
        inventory.InventoryController.RemoveAt(slotIndex);
        gameObject.SetActive(false);
    }

}
