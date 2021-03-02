using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEvents;

[CreateAssetMenu(fileName = "new inventory", menuName ="inventory/base")]
public class Inventory: ScriptableObject
{
    [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
    [SerializeField] private ItemSlot testItemSlot = new ItemSlot();
    public InventoryController InventoryController {get;} = new InventoryController(20);

    public void OnEnable()
    {
        InventoryController.OnItemUpdated += onInventoryItemsUpdated.Raise;
    }
    public void OnDisable()
    {
        InventoryController.OnItemUpdated -= onInventoryItemsUpdated.Raise;
    }
    [ContextMenu("test Add")]
    public void TestAdd()
    {
        InventoryController.AddItem(testItemSlot);
    }
}
