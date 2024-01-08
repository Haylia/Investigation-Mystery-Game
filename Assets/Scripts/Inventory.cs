using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour // shows picked up items
{
    private ProtagInfo protagInfo;
    private GameObject inventoryView;
    private GameObject inventoryContent;
    private EvidenceSelect e;

    List<GameObject> inventory = new List<GameObject>();
    List<string> added = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
        protagInfo = gameObject.GetComponentInParent<ProtagInfo>();
        inventoryView = transform.Find("InventoryView").gameObject;
        inventoryContent = inventoryView.transform.Find("Viewport/InventoryContent").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpen()
    {
        Debug.Log("inventory opened");
        inventory = protagInfo.getInventory();

        foreach (GameObject item in inventory)
        {
            if (!added.Contains(item.GetComponent<ItemInfo>().getName()))
            {
                GameObject canvas = new GameObject();
                canvas.AddComponent<VerticalLayoutGroup>();
                //canvas.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
                //canvas.GetComponent<VerticalLayoutGroup>().childControlWidth = false;

                GameObject i = new GameObject();
                i.AddComponent<TextMeshProUGUI>();
                i.GetComponent<TextMeshProUGUI>().SetText(item.GetComponent<ItemInfo>().getName());
                i.GetComponent<TextMeshProUGUI>().fontSize = 12;
                GameObject copy = new GameObject();
                copy = Instantiate(item);
                foreach (Transform child in copy.transform)
                {
                    child.gameObject.SetActive(false);
                    Destroy(child.gameObject);
                }
                //Destroy(copy.GetComponent<ObjectScript>());
                Sprite s = copy.GetComponent<SpriteRenderer>().sprite;
                copy.AddComponent<Image>();
                copy.GetComponent<Image>().sprite = s;


                copy.AddComponent<Button>();
                copy.GetComponent<Button>().onClick.AddListener(delegate { click(copy); });

                copy.transform.SetParent(canvas.transform);
                i.transform.SetParent(canvas.transform);
                canvas.transform.SetParent(inventoryContent.transform);

                //Destroy(copy.GetComponent<SpriteRenderer>().sprite);
                added.Add(item.GetComponent<ItemInfo>().getName());


            }



        }
        inventoryView.SetActive(true);
        inventoryContent.SetActive(true);
        


    }

    private void selectItem(string itemName)
    {
        e = GameObject.Find("EvidenceSelect").GetComponent<EvidenceSelect>(); //should only find the current active one
        e.selected(itemName);
    }

    private void click(GameObject copy)
    {
        Debug.Log("inventory item clicked");

        GameObject itemPanel;
        GameObject select;

        if (copy.transform.childCount > 0)
        {
            itemPanel = copy.transform.Find("ItemPanel").gameObject;
            select = copy.transform.Find("Select").gameObject;
        }
        else
        {
            itemPanel = new GameObject();
            itemPanel.name = "ItemPanel";
            itemPanel.SetActive(false);
            itemPanel.AddComponent<RectTransform>();
            itemPanel.transform.localPosition = Vector3.zero;
            itemPanel.GetComponent<RectTransform>().sizeDelta = copy.GetComponent<RectTransform>().sizeDelta;

            GameObject b = new GameObject();
            b.name = "bg";
            b.AddComponent<Image>();
            b.GetComponent<Image>().color = Color.black;
            //b.GetComponent<RectTransform>().sizeDelta = new Vector2(200,200);
            b.GetComponent<RectTransform>().sizeDelta = itemPanel.GetComponent<RectTransform>().sizeDelta;


            GameObject itemText = new GameObject();
            itemText.name = "ItemText";
            itemText.AddComponent<TextMeshProUGUI>();
            itemText.GetComponent<TextMeshProUGUI>().fontSize = 12;
            itemText.GetComponent<TextMeshProUGUI>().enableWordWrapping = true;
            itemText.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
            itemText.GetComponent<TextMeshProUGUI>().fontSizeMin = 1;
            itemText.GetComponent<TextMeshProUGUI>().fontSizeMax = 12;
            //itemText.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
            itemText.GetComponent<RectTransform>().sizeDelta = itemPanel.GetComponent<RectTransform>().sizeDelta;

            itemText.transform.SetParent(b.transform);
            b.transform.SetParent(itemPanel.transform);
            itemPanel.transform.SetParent(copy.transform);

            itemText.transform.localPosition = Vector3.zero;
            b.transform.localPosition = Vector3.zero;
            itemPanel.transform.localPosition = Vector3.zero;
            //itemPanel.AddComponent<Canvas>();

            select = new GameObject();
            select.name = "Select";
            select.AddComponent<Button>();
            //select.AddComponent<Image>();
            //select.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
            select.GetComponent<Button>().onClick.AddListener(delegate { selectItem(copy.GetComponent<ItemInfo>().getName()); });
            GameObject selectText = new GameObject();
            selectText.AddComponent<TextMeshProUGUI>();
            selectText.GetComponent<TextMeshProUGUI>().SetText("Select");

            selectText.transform.SetParent(select.transform);
            selectText.transform.localPosition = Vector3.zero;
            select.transform.SetParent(copy.transform);
            select.transform.localPosition = Vector3.zero;
        }

        if (itemPanel.activeSelf)
        {
            itemPanel.SetActive(false);
        }
        else
        {
            copy.GetComponent<Item>().itemClicked();
            copy.GetComponent<Item>().Inspect();
            itemPanel.SetActive(true);
            itemPanel.transform.Find("bg/ItemText").GetComponent<TextMeshProUGUI>().SetText(copy.GetComponent<Item>().currentInspect);
            select.SetActive(protagInfo.accusing);
        }
    }
}
