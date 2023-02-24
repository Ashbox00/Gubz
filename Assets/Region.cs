using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(this.transform);
        Debug.Log(other);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
