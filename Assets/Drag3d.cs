using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class Drag3d : MonoBehaviour
{
   
    private Camera mainCamera;
    private float CameraDistance;
    public Vector3 NewWorldPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        Physics.IgnoreLayerCollision(6,6);
    }

    // Update is called once per frame
    public void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, CameraDistance);
        NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
        
    }
    public void OnMouseUp(){
        transform.position = transform.parent.position;
    }

}
