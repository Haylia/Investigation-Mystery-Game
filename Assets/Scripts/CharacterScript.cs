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
            transform.Find("DialogueOptions").gameObject.SetActive(false);
            transform.Find("Next").gameObject.SetActive(false);
            transform.Find("Record").gameObject.SetActive(false);
            transform.Find("Close").gameObject.SetActive(false);
            transform.Find("EvidenceSelect").gameObject.SetActive(false);
            transform.Find("EndAccusation").gameObject.SetActive(false);
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
}
