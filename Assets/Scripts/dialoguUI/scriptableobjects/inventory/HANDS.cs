using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEvents;

[CreateAssetMenu(fileName = "new hand", menuName = "inventory/hand")]
public class HANDS : ScriptableObject
{
    [SerializeField] private VoidEvent onInventoryItemsAdded = null;
    [SerializeField] private VoidEvent onInventoryItemsRemoved = null;
    [SerializeField] private ItemSlot[] testItemSlot; //change this to card
    public InventoryController InventoryController { get; } = new InventoryController(3); //not renaming this but this is for
    //where players play their hand. 

    public void OnEnable()
    {
        //InventoryController.OnItemUpdated += onInventoryItemsUpdated.Raise;
    }
    public void OnDisable()
    {
        //InventoryController.OnItemUpdated -= onInventoryItemsUpdated.Raise;
    }
    [ContextMenu("test Add")]
    public void TestAdd()
    {
        for(int i=0; i < testItemSlot.Length; i++)
        {
            InventoryController.AddItem(testItemSlot[i]);
        }
        
        
    }
}
