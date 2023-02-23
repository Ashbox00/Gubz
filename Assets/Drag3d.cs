using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class Drag3d : MonoBehaviour
{
    public Transform parentToReturnTo = null;
    private Camera mainCamera;
    private float CameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraDistance = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    public void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, CameraDistance);
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
        
    }

}
