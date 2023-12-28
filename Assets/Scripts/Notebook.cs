using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour //shows recorded testimony
{

    public ProtagInfo protagInfo;

    Dictionary<string, string> testimony = new Dictionary<string, string>();
    Dictionary<GameObject, string> characterToTestimony = new Dictionary<GameObject, string>();

    Dictionary<string, string> testimonyIDToDisplayID = new Dictionary<string, string>();


    //should be organised by character that said it
    //should display an id (not same as id used in flags)
    //should show contents of testimony

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onOpen()
    {
        testimony = protagInfo.getTestimony();
        characterToTestimony = protagInfo.getCharacterToTestimony();
    }
}
