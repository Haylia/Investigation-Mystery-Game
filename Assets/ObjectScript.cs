using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectScript : MonoBehaviour
{

    //public string[] fingerprints;
    private GameObject itemPanel;

    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        Debug.Log(gameObject);
        //show menu
        //panel.SetActive
        //if its the object
        if (itemPanel.activeSelf)
        {
            itemPanel.SetActive(false);
        }
        else
        {
            itemPanel.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("object created");
        itemPanel = GameObject.Find("ItemInfo");
        itemPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
