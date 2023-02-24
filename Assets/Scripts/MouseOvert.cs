using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class MouseOvert : MonoBehaviour
{
   public Drag3d obj = new Drag3d();

    

    // Start is called before the first frame update
   void IsOver(){
    float w = gameObject.transform.localScale.x;
    float h = gameObject.transform.localScale.y;
        if(obj.transform.position.x >= gameObject.transform.position.x - (w/2) && obj.transform.position.x <= gameObject.transform.position.x + (w/2) ){
            print(gameObject.name);
        }
        
   }
}
