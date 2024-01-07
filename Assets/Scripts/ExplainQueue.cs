using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplainQueue : MonoBehaviour
{
    public Stack<string> explainQueue = new Stack<string>();
    //private GameObject dialogueBox;

    private GameObject nextButton;
    private GameObject closeButton;
    private ProtagInfo p;
    // Start is called before the first frame update
    void Start()
    {
        //dialogueBox = GameObject.Find("DialogueBox");

        nextButton = transform.Find("NextExplain").gameObject;
        closeButton = transform.Find("CloseExplain").gameObject;
        p = GetComponentInParent<ProtagInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void next()
    {
        if (explainQueue.TryPeek(out string result))
        {
            gameObject.GetComponent<TextMeshProUGUI>().SetText(explainQueue.Pop());
        }
        else
        {
            //GameObject.Find("Next").SetActive(false);
            // GameObject.Find("CloseDialogue").SetActive(true);
            closeButton.SetActive(true);
        }
    }

    public void close()
    {
        p.explaining = false;
        //gameObject.GetComponentInParent<Character>().talkEnd();
        gameObject.SetActive(false);
        //closeButton.SetActive(false);
    }
}
