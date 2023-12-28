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
            GameObject.Find("DialogueOptions").SetActive(false);
            GameObject.Find("Next").SetActive(false);
            GameObject.Find("Record").SetActive(false);
            GameObject.Find("Close").SetActive(false);
            GameObject.Find("EvidenceSelect").SetActive(false);
            GameObject.Find("EndAccusation").SetActive(false);
        }
        else
        {
            characterMenu.SetActive(true);
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
