using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : InventoryObject
{
    [Header("item data")]
    [SerializeField][Min(0)]private int sellPrice= 1;
    [SerializeField][Min(1)]private int maxStack=1;

    public override string colorName
    {
        get{return name;}
    }
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;

}
