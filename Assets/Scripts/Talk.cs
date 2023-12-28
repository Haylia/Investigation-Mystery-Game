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

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        //optionPrefab = GameObject.Find("Option");
        dialogeBox = GameObject.Find("DialogueBox");
        dialogueOptions = GameObject.Find("DialogueOptions");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talkStart()
    {
        while (dialogeBox.transform.childCount > 0)
        {
            Destroy(dialogueOptions.GetComponentInChildren<Button>().gameObject);
        }
        character.talk();
        generateOptions(character.getAvailableTalk().Keys.ToList());

        dialogue();

        GameObject.Find("Next").SetActive(true);
        GameObject.Find("Record").SetActive(true);
    }

    void generateOptions(List<string> options)
    {
        foreach (string op in options)
        {
            GameObject b = new GameObject();
            b.name = op;
            b.AddComponent<Button>();
            b.GetComponentInChildren<TextMeshProUGUI>().SetText(op);
            b.GetComponent<Button>().onClick.AddListener(delegate { optionSelected(op); });
            b.transform.SetParent(dialogueOptions.transform);
        }
    }

    void optionSelected(string option)
    {
        character.talking(option);
        dialogueOptions.SetActive(false);
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
    }
}