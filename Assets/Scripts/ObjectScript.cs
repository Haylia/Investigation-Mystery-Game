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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI clicked");
        }
        else
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
            transform.Find("Canvas/ItemInfo/ObjectDesc").gameObject.GetComponent<TextMeshProUGUI>().SetText(item.currentInspect);
            transform.Find("Canvas/ItemInfo/ObjectName").gameObject.GetComponent<TextMeshProUGUI>().SetText(itemInfo.getName());

            transform.Find("Canvas/ItemInfo/PickUp").gameObject.SetActive(itemInfo.getCanPickUp());

            transform.Find("Canvas/ItemInfo/Present").gameObject.SetActive(protageInfo.accusing);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("object created");
        itemPanel = transform.Find("Canvas/ItemInfo").gameObject;
        itemPanel.SetActive(false);
        protageInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
        item = gameObject.GetComponent<Item>();
        itemInfo = gameObject.GetComponent<ItemInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu()
    {
        itemPanel.SetActive(false);
    }
}
