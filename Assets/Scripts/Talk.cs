using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{

    private Character character;
    //private GameObject optionPrefab;
    private GameObject dialogeBox;
    private GameObject dialogueOptions;
    private GameObject next;
    private GameObject record;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        //optionPrefab = GameObject.Find("Option");
        dialogeBox = character.transform.Find("Canvas/CharacterMenu/DialogueBox").gameObject;
        dialogueOptions = transform.Find("DialogueOptions").gameObject;
        next = character.transform.Find("Canvas/CharacterMenu/DialogueBox/Next").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talkStart()
    {

        //dialogueOptions.SetActive(true);
        character.talk();
        generateOptions(character.getAvailableTalk().Keys.ToList());

        //dialogue();

        //dialogeBox.transform.Find("Next").gameObject.SetActive(true);
        //dialogeBox.transform.Find("Record").gameObject.SetActive(true);
    }


    void generateOptions(List<string> options)
    {
        Debug.Log("generating options");
        Debug.Log(dialogueOptions.transform.childCount);

        foreach (Transform child in dialogueOptions.transform)
        {
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }


        foreach (string op in options)
        {
            GameObject b = new GameObject();
            b.name = op;
            b.AddComponent<Button>();
            b.AddComponent<TextMeshProUGUI>();
            b.GetComponent<TextMeshProUGUI>().SetText(op);
            b.GetComponent<Button>().onClick.AddListener(delegate { optionSelected(op); });
            //b.transform.SetParent(dialogueOptions.transform.Find("/Viewport/Content"));
            b.transform.SetParent(dialogueOptions.transform);
            b.SetActive(true);
            Debug.Log(b.name);
        }
        dialogueOptions.SetActive(true);
    }

    void optionSelected(string option)
    {
        character.talking(option);
        dialogueOptions.SetActive(false);
        ////////////////////////////////////////////reemeber to change name
        if (character.gameObject.GetComponent<CharacterInfo>().getName() == "Margaret" && option == TestimonyMasterList.MaidDefThoughts)
        {
            GameObject.Find("Protag").GetComponent<ProtagInfo>().pickUpItem(GameObject.Find("NoticeOfDismissal"));
        }
        dialogue();
        dialogeBox.transform.Find("Record").gameObject.SetActive(true);
    }

    void dialogue()
    {
        string dialogue = character.currentResponse;
        Stack<string> organisedDialogue = new Stack<string>();

        /* for splitting on somelength
         
        string[] dialogueSplit = dialogue.Split(" ");
        while (dialogueSplit.Length > 0)
        {
            string str = "";
            foreach (string s in dialogueSplit)
            {
                if (str.Length > 100)
                {
                    break;
                }

                str = str + s + " ";
            }
            organisedDialogue.Push(str);
            dialogueSplit.Take(str.Length);
        }
        */

        //for spliting on specific character;
        string[] dialogueSplit = dialogue.Split("***");
        foreach (string s in dialogueSplit)
        {
            organisedDialogue.Push(s);
        }


        dialogeBox.GetComponent<TextMeshProUGUI>().SetText(organisedDialogue.Pop());
        dialogeBox.GetComponent<DialogueQueue>().dialogueQueue = organisedDialogue;
        Debug.Log(organisedDialogue);
        if (organisedDialogue.Count > 1)
        {
            next.SetActive(true);
        }
    }
}
