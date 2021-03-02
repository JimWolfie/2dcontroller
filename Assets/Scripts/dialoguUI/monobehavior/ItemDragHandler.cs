using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using SOEvents;

[RequireComponent(typeof (CanvasGroup))]
public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField]protected ItemSlotUI itemSlotUI = null;
    [SerializeField]protected InventoryObjectEvent onStartMouseOver = null;
    [SerializeField]protected VoidEvent onMouseOverEnd= null;

    private CanvasGroup canvasGroup = null;
    private Transform orginalParent = null;
    private bool isHovering = false;
  
    public ItemSlotUI ItemSlotUI => itemSlotUI;

    void Start()=>canvasGroup = GetComponent<CanvasGroup>();

    private void OnDisable()
    {
        if(isHovering)
        {
            onMouseOverEnd.Raise();
            isHovering=false;
            
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            onMouseOverEnd.Raise();//turn off the pop up!
            orginalParent = transform.parent; //store for later
            transform.SetParent(transform.parent.parent); //set parent two up
            canvasGroup.blocksRaycasts = false; //we care whatts bellow 
        }
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition; //mouse can move now
        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            transform.SetParent(orginalParent); //undoing on button down
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        onStartMouseOver.Raise(itemSlotUI.SlotItem);
        isHovering = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        onMouseOverEnd.Raise();
        isHovering = false;
    }
}
