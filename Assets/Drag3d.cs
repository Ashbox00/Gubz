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

    private Region _ParentRegion = null;
    public LayerMask IgnoreMe;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        Physics.IgnoreLayerCollision(6,6);
    }

    // Update is called once per frame
    void Update() {
        _ParentRegion = GetComponentInParent<Region>();
    }

    public void OnMouseDrag()
    {   IgnoreLayer(0,5);
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, CameraDistance - 0.1f);
        NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
    }
    public void OnMouseUp(){
        if (_ParentRegion) {
            transform.localPosition = Vector3.zero;
            _ParentRegion.OrganizeChildren();
        }
    }

}
