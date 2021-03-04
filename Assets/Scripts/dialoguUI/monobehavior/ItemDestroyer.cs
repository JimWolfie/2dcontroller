using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    [SerializeField]private Inventory inventory = null;
    [SerializeField]private TextMeshProUGUI confirmText =null;

    private int slotIndex = 0;

    private void OnDisable() => slotIndex =-1;

    public void Activate(ItemSlot itemSlot, int slotIndex)
    {
        UseItem(itemSlot, slotIndex);
    }
    public void Destroy()
    {
        if(slotIndex!=-1)
        {

            inventory.InventoryController.RemoveAt(slotIndex);
            gameObject.SetActive(false);
        }

    }

    public IEnumerator UseItem(ItemSlot itemSlot, int slotIndex)
    {
        this.slotIndex = slotIndex;
        confirmText.text = $"Attack!";
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Destroy();
    }
}
