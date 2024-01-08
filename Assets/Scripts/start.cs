using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    public void clickStart()
    {
        GameObject.Find("ExplainCanvas").SetActive(false);
        GameObject.Find("ProtagMenu").SetActive(false);
         GameObject.Find("Foyer Room Shade").SetActive(false);
         // GameObject.Find("Parlour Room Shade").SetActive(false);
         GameObject.Find("Dining Room Shade").SetActive(false);
         GameObject.Find("Library Room Shade").SetActive(false);
        GameObject.Find("Lounge Room Shade").SetActive(false);
        GameObject.Find("Pantry Room Shade").SetActive(false);
         GameObject.Find("Kitchen Room Shade").SetActive(false);
        GameObject.Find("Chefs Room Shade").SetActive(false);
        GameObject.Find("Maids Room Shade").SetActive(false);
        GameObject.Find("Butlers Room Shade").SetActive(false);
         GameObject.Find("Child Room Shade").SetActive(false);
        GameObject.Find("Host Room Shade").SetActive(false);
         GameObject.Find("Guest 1 Room Shade").SetActive(false);
         GameObject.Find("Study Room Shade").SetActive(false);
         GameObject.Find("Guest 2 Room Shade").SetActive(false);
        gameObject.SetActive(false);
    }

}
