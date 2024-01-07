using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private GameObject characterMenu;
    private Character character;
    private CharacterInfo characterInfo;



    private void OnMouseDown()
    {
        character = gameObject.GetComponent<Character>();
        characterInfo = gameObject.GetComponent<CharacterInfo>();

        if (characterMenu.activeSelf)
        {
            characterMenu.SetActive(false);
        }
        else
        {
            characterMenu.SetActive(true);
            transform.Find("Canvas/CharacterMenu/Talk/DialogueOptions").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/DialogueBox/Next").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/DialogueBox/Record").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/DialogueBox/CloseDialogue").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/Accuse/EvidenceSelect").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/Accuse/EndAccusation").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/Show/ShowView").gameObject.SetActive(false);
            transform.Find("Canvas/CharacterMenu/Show/CloseShow").gameObject.SetActive(false);
        }


        character.characterClicked();
    }


    // Start is called before the first frame update
    void Start()
    {
        characterMenu = GameObject.Find("CharacterMenu");
        characterMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu()
    {
        characterMenu.SetActive(false);
    }
}
