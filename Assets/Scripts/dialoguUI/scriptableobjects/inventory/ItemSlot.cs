using UnityEngine;
using System;

[Serializable]
public struct ItemSlot  
{

//wrapper for consumables which are scriptable objects. 
   public Consumable item;
   [Min(1)] public int quantity;

    public ItemSlot(Consumable item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;

    }

   
    public override bool Equals(object obj)
    {
        if(!(obj is ItemSlot itm))
        {
            return false;
        }
        return this.item == itm.item;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }




    //overrides for == and !=
    public static bool operator ==(ItemSlot a, ItemSlot b){return a.Equals(b);}
    public static bool operator !=(ItemSlot a, ItemSlot b) { return !a.Equals(b);}
}
