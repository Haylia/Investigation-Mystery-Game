using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueQueue : MonoBehaviour
{

    public Stack<string> dialogueQueue = new Stack<string>();
    private GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GameObject.Find("DialogueBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        if (dialogueQueue.TryPeek(out string result))
        {
            dialogueBox.GetComponent<TextMeshProUGUI>().SetText(dialogueQueue.Pop());
        }
        else
        {
            GameObject.Find("Next").SetActive(false);
            GameObject.Find("CloseDialogue").SetActive(true);
        }
    }

    public void close()
    {
        gameObject.GetComponentInParent<Character>().talkEnd();
        GameObject.Find("Record").SetActive(false);
    }
}
