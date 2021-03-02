using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : ItemSlotUI, IDropHandler
{
    [SerializeField]private Inventory inventory = null;
    [SerializeField]private TextMeshProUGUI itemQuantityText = null;

    public override InventoryObject SlotItem
    {
        get {
            return ItemSlot.item;
        }
        set { }
    }

    public ItemSlot ItemSlot => inventory.InventoryController.GetSlotByIndex(SlotIndex);

    public override void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
        if(itemDragHandler == null){return;}//this should never happpen but like /shrug

        if((itemDragHandler.ItemSlotUI as InventorySlot) != null)
        {//swapping consumables n stuff
            inventory.InventoryController.Swap(itemDragHandler.ItemSlotUI.SlotIndex, SlotIndex);
        }
    }
    public override void UpdateSlotUI()
    {
        if(ItemSlot.item ==null)
        {
            EnableSlotUI(false);
            return;
        }

        EnableSlotUI(true);
        iconImage.sprite =ItemSlot.item.Icon;
        itemQuantityText.text = ItemSlot.quantity >1? ItemSlot.quantity.ToString()  : "";
    }

    protected override void EnableSlotUI(bool enable)
    {
        base.EnableSlotUI(enable);//does the icon
        itemQuantityText.enabled = enable;
    }
}
