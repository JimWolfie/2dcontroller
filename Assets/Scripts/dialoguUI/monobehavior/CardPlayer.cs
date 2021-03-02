using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    [SerializeField]private Inventory inventory = null; //the object wit
    
    [SerializeField]private HANDS cardsPlayed = null;

    private int slotIndex = 0;

    private void OnDisable()=> slotIndex =-1;

    public void Activate(ItemSlot itemSlot, int slotIndex)
    {
        //this turns on the pannel where the cards are played. 
        //fires the attack. then sets the card to the gy. 
        this.slotIndex = slotIndex;
        
        gameObject.SetActive(true);
    }
    public void Destroy()
    {
        inventory.InventoryController.RemoveAt(slotIndex);
        gameObject.SetActive(false);
    }

}
