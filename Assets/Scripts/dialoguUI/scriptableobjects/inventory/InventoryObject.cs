using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryObject : ScriptableObject
{
    //inventory objects are spells or consumables.
    [Header("shared info")]
    [SerializeField]private new string name = "new inventory object";
    [SerializeField]private Sprite icon = null;

    public string Name => name;
    public abstract string colorName {get;}
    public Sprite Icon => icon;
    public abstract string GetDisplayText();




}

