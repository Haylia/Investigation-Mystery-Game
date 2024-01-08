using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueQueue : MonoBehaviour
{

    public Stack<string> dialogueQueue = new Stack<string>();
    //private GameObject dialogueBox;

    private GameObject nextButton;
    private GameObject recordButton;
    private GameObject closeButton;
    private Character c;
    // Start is called before the first frame update
    void Start()
    {
        //dialogueBox = GameObject.Find("DialogueBox");

        nextButton = transform.Find("Next").gameObject;
        recordButton = transform.Find("Record").gameObject;
        closeButton = transform.Find("CloseDialogue").gameObject;
        c = GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogueQueue.Pop());
        if (dialogueQueue.TryPeek(out string result))
        {
            //gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogueQueue.Pop());
            nextButton.SetActive(true);
        }
        else
        {
            //GameObject.Find("Next").SetActive(false);
            // GameObject.Find("CloseDialogue").SetActive(true);
            closeButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }

    public void close()
    {
        c.responding = false;
        gameObject.GetComponentInParent<Character>().talkEnd();
        recordButton.SetActive(false);
        closeButton.SetActive(false);


    }
}
