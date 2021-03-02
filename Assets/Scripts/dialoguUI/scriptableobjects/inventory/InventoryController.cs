using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryController :IItemContainer
{
    private ItemSlot[] itemSlots = new ItemSlot[0];

    public Action OnItemUpdated =  delegate{ };

    public InventoryController(int size) => itemSlots = new ItemSlot[size];

    public ItemSlot GetSlotByIndex(int index) => itemSlots[index];
    public ItemSlot AddItem(ItemSlot item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].item != null)
            {
                if(itemSlots[i].item == item.item)
                {
                    int remainingSpace = itemSlots[i].item.MaxStack - itemSlots[i].quantity;
                    if (itemSlots[i].quantity <= remainingSpace)
                    {
                        itemSlots[i].quantity += item.quantity;
                        item.quantity =0;
                        OnItemUpdated.Invoke();
                        return item;
                     
                    }else if(remainingSpace > 0)
                    {
                        itemSlots[i].quantity += remainingSpace;
                        item.quantity -= remainingSpace;
                    }
                }
            }
        }
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].item == null)
            {
                if(item.quantity <= item.item.MaxStack)
                {
                    itemSlots[i]= item;
                    
                    item.quantity = 0;
                    OnItemUpdated.Invoke();
                    return item;
                }
            }else
            {
                itemSlots[i] = new ItemSlot(item.item, item.item.MaxStack);
                item.quantity -= item.item.MaxStack;
            }
        }
        OnItemUpdated.Invoke();
        return item;
    }

    public int GetTotal(Consumable item)
    {
        int total = 0;
        foreach(ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item == null){continue;}
            if(itemSlot.item != item ){continue;}

            total += itemSlot.quantity;
        }
        return total;
    }

    public bool HasItem(Consumable item)
    {
        foreach(ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item == null)
            { continue; }
            if(itemSlot.item != item)
            { continue; }
            return true;
        }
        return false;
        }

    public void RemoveAt(int indexSlot)
    {
        if (indexSlot < 0 || indexSlot > itemSlots.Length -1){return;}
        itemSlots[indexSlot]= new ItemSlot();
        OnItemUpdated.Invoke();
        return;
    }

    public void RemoveItem(ItemSlot item)
    {
        for(int i = 0;i < itemSlots.Length; i++)
        {
            if(itemSlots[i] != null)
            {
                if(itemSlots[i].item == item.item)
                {
                    if(itemSlots[i].quantity < item.quantity)
                    {
                        item.quantity -= itemSlots[i].quantity;
                        itemSlots[i] = new ItemSlot();
                    }else
                    {
                        itemSlots[i].quantity -= item.quantity;
                        if (itemSlots[i].quantity == 0)
                        {
                            itemSlots[i] = new ItemSlot();
                            OnItemUpdated.Invoke();
                            return;
                        }
                    }
                }
            }
        }
    }

    public void Swap(int index1, int index2)
    {
        ItemSlot firstItem = itemSlots[index1];
        ItemSlot secondItem = itemSlots[index2];
        if(firstItem == secondItem){return;}
        if(secondItem != null)
        {
            if(firstItem.item == secondItem.item)
            {
                int secondRemainingSpace = secondItem.item.MaxStack - secondItem.quantity;
                
                if(firstItem.quantity <= secondRemainingSpace)
                {
                    itemSlots[index2].quantity += firstItem.quantity;
                    itemSlots[index1] = new ItemSlot();
                    OnItemUpdated.Invoke();
                    return;
                }
                
            }
        }
        itemSlots[index1] = secondItem;
        itemSlots[index2] = firstItem;
        OnItemUpdated.Invoke();
    }
}
