using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Collider))]
public class TurnButton : MonoBehaviour
{
   
   
    public float playerturn = 0;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    public void OnMouseDown(){
        // Cameron take a look at this, its not working for one but what Im realizing is instead of turning of Drag3d we should turn off the ability to 
        // place cards under a parent while its opponents turn. Also I know the if statement is wrong and itll be off when its your turn but thats ok for now
        
            if(playerturn % 2 == 0){
                var endCard = GameObject.FindWithTag("Test");
                endCard.GetComponent<Drag3d>().enabled = false;
                Debug.Log("The turn ended");
            }
            
        } 
}

