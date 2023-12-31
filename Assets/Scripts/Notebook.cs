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
        //characterNames.Add("Margaret");
       //characterNames.Add("Silvia");
        //characterNames.Add("Agnes");
        //characterNames.Add("Bernard");
       // characterNames.Add("Chef");
        //characterNames.Add("Bartholomew");
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
        if (currentPage == nameToPage.Count -1) // show 1 page
        {
            var p1 = nameToPage[characterNames[currentPage]];
            p1.SetActive(true);
            p1.transform.SetParent(pageDisplay.transform);
            nextPage.SetActive(false);
        }

        else if (currentPage <= nameToPage.Count + 1) //show 2 pages
        {
            var p1 = nameToPage[characterNames[currentPage]];
            p1.SetActive(true);
            p1.transform.SetParent(pageDisplay.transform);
            var p2 = nameToPage[characterNames[currentPage + 1]];
            nextPage.SetActive(true);
            p2.SetActive(true);
            p2.transform.SetParent(pageDisplay.transform);
        }
        if (currentPage <= 1)
        {
            previousPage.SetActive(false);
        }
        if(currentPage >= nameToPage.Count)
        {
            nextPage.SetActive(false);
        }

    }

    void hidePages()
    {
        pageDisplay.transform.DetachChildren();
        //GameObject pagesDisplay = GameObject.Find("PageDisplay");
        if (currentPage <= nameToPage.Count) // show 1 page
        {
            Debug.Log("hiding page " + characterNames[currentPage]);
            nameToPage[characterNames[currentPage]].SetActive(false);
        }
     

        else if (currentPage <= nameToPage.Count + 1) //show 2 pages
        {
            nameToPage[characterNames[currentPage]].SetActive(false);
            nameToPage[characterNames[currentPage + 1]].SetActive(false);
        }

    }

    void createPages()
    {
        Debug.Log("creating pages");
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
                page.AddComponent<ScrollRect>();
                page.GetComponent<Image>().color = Color.black;
      

                name.transform.SetParent(page.transform);
                nameToPage.Add(character.GetComponent<CharacterInfo>().getName(),page);

                page.SetActive(false);
                characterNames.Add(character.GetComponent<CharacterInfo>().getName());
                Debug.Log("new page for " + character.GetComponent<CharacterInfo>().getName() + "at " + page);

                GameObject pageContent = new GameObject();
                pageContent.name = "PageContent";
                pageContent.transform.SetParent(page.transform);
                pageContent.AddComponent<VerticalLayoutGroup>();

                page.GetComponent<ScrollRect>().content = pageContent.GetComponent<RectTransform>();
                page.GetComponent<ScrollRect>().horizontal = false;
                page.GetComponent<ScrollRect>().vertical = true;
                page.GetComponent<ScrollRect>().scrollSensitivity = 20;
            }
            else
            {
                page = nameToPage[character.GetComponent<CharacterInfo>().getName()];

                page.SetActive(false);
            }

            foreach (string id in characterToTestimonyID[character])
            {
                if (idToContainer[id].transform.parent != page.transform.Find("PageContent"))
                {
                    idToContainer[id].transform.SetParent(page.transform.Find("PageContent"));
                    //idToContainer[id].GetComponent<RectTransform>().sizeDelta = new Vector2 (page.transform.Find("PageContent").GetComponent<RectTransform>().sizeDelta.x, 0);
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
                //GameObject displayId = new GameObject();
                //displayId.AddComponent<TextMeshProUGUI>();
                //displayId.GetComponent<TextMeshProUGUI>().SetText(testimonyIDToDisplayID[id]);
                //displayId.GetComponent<TextMeshProUGUI>().SetText(id);
                //TextMeshPro testimonyContent = new TextMeshPro();
                GameObject testimonyContent = new GameObject();
                testimonyContent.AddComponent<TextMeshProUGUI>();
                testimonyContent.GetComponent<TextMeshProUGUI>().SetText(testimony[id]);
                testimonyContent.GetComponent<TextMeshProUGUI>().fontSize = 16;

                GameObject container = new GameObject();
                container.AddComponent<RectTransform>();
                container.AddComponent<CanvasRenderer>();
                container.AddComponent<Image>();
                container.AddComponent<VerticalLayoutGroup>();

                //displayId.transform.SetParent(container.transform);
                testimonyContent.transform.SetParent(container.transform);

                container.AddComponent<Selectable>();
                container.AddComponent<Testimony>();
                container.GetComponent<Testimony>().id = id;

                container.GetComponent<Image>().color = Color.black;

                idToContainer.Add(id, container);
            }
        }
    }

    void selected()
    {

    }
}
