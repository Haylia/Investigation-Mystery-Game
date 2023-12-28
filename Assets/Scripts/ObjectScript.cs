using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectScript : MonoBehaviour
{

    //public string[] fingerprints;
    private GameObject itemPanel;
    private Item item;
    private ItemInfo itemInfo;

    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        Debug.Log(gameObject);
        //show menu
        //panel.SetActive
        //if its the object

        item = gameObject.GetComponent<Item>();
        itemInfo = gameObject.GetComponent<ItemInfo>();

        item.itemClicked();
        item.Inspect();


        if (itemPanel.activeSelf)
        {
            itemPanel.SetActive(false);
        }
        else
        {
            itemPanel.SetActive(true);
        }

        Debug.Log(item.currentInspect);
        GameObject.Find("ObjectDesc").GetComponent<TextMeshProUGUI>().SetText(item.currentInspect);
        GameObject.Find("ObjectName").GetComponent<TextMeshProUGUI>().SetText(itemInfo.getName());

        GameObject.Find("PickUp").SetActive(itemInfo.canPickUp);
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
