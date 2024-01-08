using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    private Character character;
    private GameObject showView;
    private GameObject showContent;
    private List<GameObject> inventory;
    private List<GameObject> showInventory;
    private List<string> added;
    private GameObject dialogueBox;
    private GameObject closeButton;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        showView = transform.Find("ShowView").gameObject;
        showContent = showView.transform.Find("Viewport/ShowContent").gameObject;
        inventory = GameObject.Find("Protag").GetComponent<ProtagInfo>().getInventory();
        showInventory = new List<GameObject>();
        added = new List<string>();
        dialogueBox = character.transform.Find("Canvas/CharacterMenu/DialogueBox").gameObject;
        closeButton = transform.Find("CloseShow").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        //copy inventory to show inventory
        loadItems();
        showView.SetActive(true);
        closeButton.SetActive(true);
        //show view active
        Debug.Log("show");
    }

    public void showItem(string itemName)
    {
        Debug.Log("showItem");
        character.show(itemName);
        showView.SetActive(false);
        dialogueBox.GetComponent<TextMeshProUGUI>().SetText(character.currentResponse);
        character.showEnd(itemName);
    }

    void loadItems()
    {
        Debug.Log("loadItems");
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
                copy.GetComponent<Button>().onClick.AddListener(delegate { showItem(item.GetComponent<ItemInfo>().getName()); });

                copy.transform.SetParent(canvas.transform);
                i.transform.SetParent(canvas.transform);
                canvas.transform.SetParent(showContent.transform);

                //Destroy(copy.GetComponent<SpriteRenderer>().sprite);
                added.Add(item.GetComponent<ItemInfo>().getName());
            }
        }
    }

    public void closeShow()
    {
        showView.SetActive(false);
        closeButton.SetActive(false);
    }
}
