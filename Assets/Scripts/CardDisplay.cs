using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardSystem card;
    public TextMeshPro nameText;
    public TextMeshPro descriptionText;
    
    void Start()
    {
        
        nameText.text = card.name;
        descriptionText.text = card.descriptionText;
    }
    

   
}
