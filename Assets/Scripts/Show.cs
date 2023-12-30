using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show : MonoBehaviour
{
    private Character character;
    private GameObject showView;
    private GameObject showContent;
    private List<GameObject> inventory;
    private List<GameObject> showInventory;
    private List<string> added;
    private GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        showView = transform.Find("ShowView").gameObject;
        showContent = transform.Find("ShowContent").gameObject;
        inventory = GameObject.Find("Protag").GetComponent<ProtagInfo>().getInventory();
        showInventory = new List<GameObject>();
        added = new List<string>();
        dialogueBox = character.transform.Find("DialogueBox").gameObject;
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
        //show view active
    }

    public void showItem(string itemName)
    {
        character.show(itemName);
        showView.SetActive(false);
        dialogueBox.GetComponent<TextMeshProUGUI>().SetText(character.currentResponse);
        character.showEnd(itemName);
    }

    void loadItems()
    {
        foreach (GameObject item in inventory)
        {
            if (!added.Contains(item.GetComponent<ItemInfo>().getName())) {
                GameObject copy = new GameObject();
                copy = Instantiate(item);
                Destroy(copy.GetComponent<ObjectScript>());
                copy.AddComponent<ShowItem>();
                copy.GetComponent<ShowItem>().show = this;
                copy.transform.SetParent(showContent.transform);
                added.Add(item.GetComponent<ItemInfo>().getName()));
            }
        }
    }
}
