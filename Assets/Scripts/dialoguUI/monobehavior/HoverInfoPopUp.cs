using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;

public class HoverInfoPopUp : MonoBehaviour
{
    [SerializeField]private GameObject popupCanvasObject = null;
    [SerializeField]private RectTransform popupObject = null;
    [SerializeField]private TextMeshProUGUI infoText = null;
    [SerializeField]private Vector3 offset = new Vector3(0f, 50f, 0f);
    [SerializeField]private float padding =25f;

    private Canvas popupCanvas = null;

    private void Start()=>popupCanvas = popupCanvasObject.GetComponent<Canvas>();

    private void Update()=>FollowCursor();

    public void HideInfo()=>popupCanvasObject.SetActive(false);

    private void FollowCursor()
    {
        if(!popupCanvasObject.activeSelf){return;}

        Vector3 newPos = Input.mousePosition+offset;
        newPos.z=0f;

        float rightEdge2ScreenDistance = Screen.width - (newPos.x + popupObject.rect.width*popupCanvas.scaleFactor/2)-padding;
        if(rightEdge2ScreenDistance<0)
        {
            newPos.x += rightEdge2ScreenDistance;
        }
        float leftEdge2ScreenDistance = 0 - (newPos.x + popupObject.rect.width*popupCanvas.scaleFactor/2)+padding;
        if(leftEdge2ScreenDistance>0)
        {
            newPos.x += rightEdge2ScreenDistance;
        }
        float topEdge2ScreenDistance = Screen.height- (newPos.y + popupObject.rect.height*popupCanvas.scaleFactor)-padding;
        if(topEdge2ScreenDistance>0)
        {
            newPos.y += topEdge2ScreenDistance;
        }
        popupObject.transform.position = newPos;

    }
    public void DisplayInfo(InventoryObject infoItem)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("<size=35>").Append(infoItem).Append("</size>\n");
        builder.Append(infoItem.GetDisplayText());

        infoText.text = builder.ToString();

        popupCanvasObject.SetActive(true);

        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
    }

}
