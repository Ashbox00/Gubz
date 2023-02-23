using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int hand = 3;


    public void OnPointerEnter(PointerEventData eventdata){
        Debug.Log("OnPointerEnter");
    }
    public void OnPointerExit(PointerEventData eventdata){
        Debug.Log("OnPointerExit");
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ondrop to " + gameObject.name);

        Drag3d d = eventData.OnMouseDrag.GetComponent<Drag3d>();
        if (d != null && transform.childCount < hand ){
            d.parentToReturnTo = this.transform;
       }
    }
}
