using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
   public void OnBeginDrag(PointerEventData eventdata)
    {
        Debug.Log("OnBeginDrag");
        //zoffset.position = this.transform.position + eventdata.position;
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
   public void OnDrag(PointerEventData eventdata)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventdata.position;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
