using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
    //item slot is the struct taht holds consumables (consumables are amo, sundry, and weapons)
    //inventory objects are spells or consumables.
    ItemSlot AddItem(ItemSlot item);
    void RemoveItem(ItemSlot item);
    void RemoveAt(int indexSlot);
    void Swap(int index1, int index2);
    bool HasItem(Consumable item);
    int GetTotal(Consumable item);
}
