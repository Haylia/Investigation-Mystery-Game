using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Notebook : MonoBehaviour //shows recorded testimony
{

    private GameObject nextPage;
    private GameObject previousPage;

    private GameObject pageDisplay;

    private ProtagInfo protagInfo;

    Dictionary<string, string> testimony = new Dictionary<string, string>();
    Dictionary<GameObject, List<string>> characterToTestimonyID = new Dictionary<GameObject, List<string>>();

    Dictionary<string, string> testimonyIDToDisplayID = new Dictionary<string, string>();

    Dictionary<string, GameObject> idToContainer = new Dictionary<string, GameObject>();

    Dictionary<string, GameObject> nameToPage = new Dictionary<string, GameObject>();

    int currentPage;

    List<string> characterNames = new List<string>();

    //should be organised by character that said it
    //should display an id (not same as id used in flags)
    //should show contents of testimony

    // Start is called before the first frame update
    void Start()
    {
        //protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
        protagInfo = gameObject.GetComponentInParent<ProtagInfo>();
        pageDisplay = transform.Find("PageDisplay").gameObject;
        nextPage = transform.Find("NextPage").gameObject;
        previousPage = transform.Find("PreviousPage").gameObject;
        // set up testmony id to display id
        // set up character names
        characterNames.Add("Margaret");
        characterNames.Add("Silvia");
        characterNames.Add("Agnes");
        characterNames.Add("Bernard");
        characterNames.Add("Chef");
        characterNames.Add("Bartholomew");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpen()
    {
        Debug.Log("Notebook opened");
        testimony = protagInfo.getTestimony();
        characterToTestimonyID = protagInfo.getCharacterToTestimony();
        currentPage = 0; // technically first 2 entries

        testimonyContainers();
        createPages();
        displayPages();
    }


    void displayPages()
    {
        //GameObject pagesDisplay = GameObject.Find("PageDisplay");
        Debug.Log("pages: " + nameToPage.Count);
        if (currentPage <= nameToPage.Count) // show 1 page
        {
            var p1 = nameToPage[characterNames[currentPage]];
            p1.SetActive(true);
            p1.transform.SetParent(pageDisplay.transform);
        }

        else if (currentPage <= nameToPage.Count + 1) //show 2 pages
        {
            var p1 = nameToPage[characterNames[currentPage]];
            p1.SetActive(true);
            p1.transform.SetParent(pageDisplay.transform);
            var p2 = nameToPage[characterNames[currentPage + 1]];
            p2.SetActive(true);
            p2.transform.SetParent(pageDisplay.transform);
        }
    }

    void hidePages()
    {
        //GameObject pagesDisplay = GameObject.Find("PageDisplay");
        pageDisplay.transform.DetachChildren();

        if (currentPage <= nameToPage.Count + 1) //show 2 pages
        {
            nameToPage[characterNames[currentPage]].SetActive(false);
            nameToPage[characterNames[currentPage + 1]].SetActive(false);
        }
        else if (currentPage <= nameToPage.Count) // show 1 page
        {
            nameToPage[characterNames[currentPage]].SetActive(false);
        }
    }

    void createPages()
    {
        foreach(GameObject character in characterToTestimonyID.Keys)
        {
            GameObject page;

            if (!nameToPage.ContainsKey(character.GetComponent<CharacterInfo>().getName()))
            {
                GameObject name = new GameObject();
                //TextMeshPro name = new TextMeshPro();
                name.AddComponent<TextMeshProUGUI>();
                name.GetComponent<TextMeshProUGUI>().SetText(character.GetComponent<CharacterInfo>().getName());


                page = new GameObject();
                page.AddComponent<RectTransform>();
                page.AddComponent<CanvasRenderer>();
                page.AddComponent<Image>();
                page.AddComponent<VerticalLayoutGroup>();
                page.AddComponent<Scrollbar>();
                //page.GetComponent<Image>().color = Color.black;
      

                name.transform.SetParent(page.transform);
                nameToPage.Add(character.GetComponent<CharacterInfo>().getName(),page);

                page.SetActive(false);
            }
            else
            {
                page = nameToPage[character.GetComponent<CharacterInfo>().getName()];

                page.SetActive(false);
            }

            foreach (string id in characterToTestimonyID[character])
            {
                if (idToContainer[id].transform.parent != page.transform)
                {
                    idToContainer[id].transform.SetParent(page.transform);
                }               
            }

        }
    }

    public void turnPageForward()
    {
        hidePages();
        currentPage += 2;
        //GameObject.Find("PreviousPage").SetActive(true);
        previousPage.SetActive(true);

        if (currentPage >= nameToPage.Count)
        {
            //GameObject.Find("NextPage").SetActive(false);
            nextPage.SetActive(false);
        }

        displayPages();
    }

    public void turnPageBackward()
    {
        hidePages();
        currentPage -= 2;
        //GameObject.Find("NextPage").SetActive(true);
        nextPage.SetActive(true);

        if (currentPage <= 1)
        {
            //GameObject.Find("PreviousPage").SetActive(false);
            previousPage.SetActive(false);
        }

        displayPages();
    }

    void testimonyContainers()
    {

        foreach (string id in testimony.Keys.ToList())
        {
            if (!idToContainer.ContainsKey(id))
            {
                //TextMeshPro displayId = new TextMeshPro();
                GameObject displayId = new GameObject();
                displayId.AddComponent<TextMeshProUGUI>();
                //displayId.GetComponent<TextMeshProUGUI>().SetText(testimonyIDToDisplayID[id]);
                displayId.GetComponent<TextMeshProUGUI>().SetText(id);
                //TextMeshPro testimonyContent = new TextMeshPro();
                GameObject testimonyContent = new GameObject();
                testimonyContent.AddComponent<TextMeshProUGUI>();
                testimonyContent.GetComponent<TextMeshProUGUI>().SetText(testimony[id]);

                GameObject container = new GameObject();
                container.AddComponent<RectTransform>();
                container.AddComponent<CanvasRenderer>();
                container.AddComponent<Image>();
                container.AddComponent<VerticalLayoutGroup>();

                displayId.transform.SetParent(container.transform);
                testimonyContent.transform.SetParent(container.transform);

                container.AddComponent<Selectable>();
                container.AddComponent<Testimony>();
                container.GetComponent<Testimony>().id = id;

                idToContainer.Add(id, container);
            }
        }
    }

    void selected()
    {

    }
}
