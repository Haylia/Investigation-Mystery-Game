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
    private ProtagInfo protageInfo;

    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        Debug.Log(gameObject);
        //show menu
        //panel.SetActive
        //if its the object

        //item = gameObject.GetComponent<Item>();
        //itemInfo = gameObject.GetComponent<ItemInfo>();


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
        transform.Find("ObjectDesc").gameObject.GetComponent<TextMeshProUGUI>().SetText(item.currentInspect);
        transform.Find("ObjectName").gameObject.GetComponent<TextMeshProUGUI>().SetText(itemInfo.getName());

        transform.Find("PickUp").gameObject.SetActive(itemInfo.canPickUp);

        transform.Find("Present").gameObject.SetActive(protageInfo.accusing);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("object created");
        itemPanel = transform.Find("ItemInfo").gameObject;
        itemPanel.SetActive(false);
        protageInfo = transform.Find("Protag").gameObject.GetComponent<ProtagInfo>();
        item = gameObject.GetComponent<Item>();
        itemInfo = gameObject.GetComponent<ItemInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
