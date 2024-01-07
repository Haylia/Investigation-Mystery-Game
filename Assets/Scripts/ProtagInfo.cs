using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagInfo : MonoBehaviour
{

    public int lives = 2;
    public bool accusing;
    public bool explaining;

    Dictionary<string, bool> allFlags;
    Dictionary<string, bool> itemFlags;

    List<GameObject> inventory = new List<GameObject>();

    List<string> evidence;
    List<string> presentedEvidence;

    Dictionary<string, string> testimony;
    Dictionary<GameObject, List<string>> characterToTestimony;
    //character to dict item to response
    Dictionary<GameObject, Dictionary<string, string>> accuseDialogue;
    public string currentAccuseDialogue;

    // Start is called before the first frame update
    void Start()
    {
        accusing = false;
        explaining = false;
        allFlags = new Dictionary<string, bool>();
        itemFlags = new Dictionary<string, bool>();
        evidence = new List<string>();
        presentedEvidence = new List<string>();
        testimony = new Dictionary<string, string>();
        characterToTestimony = new Dictionary<GameObject, List<string>>();
        accuseDialogue = new Dictionary<GameObject, Dictionary<string, string>>();
        currentAccuseDialogue = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> getInventory()
    {
        return inventory;
    }

    public Dictionary<string, string> getTestimony()
    {
        return testimony;
    }

    public Dictionary<GameObject, List<string>> getCharacterToTestimony()
    {
        return characterToTestimony;
    }

    public Dictionary<string,bool> getAllFlags()
    {
        return allFlags;
    }

    public void setFlag(string flag, bool b)
    {
        if (allFlags.ContainsKey(flag))
        {
            allFlags[flag] = b;
        }
        else
        {
            allFlags.Add(flag, b);
        }
    }


    public void pickUpItem(GameObject item)
    {
        string itemName = item.GetComponent<ItemInfo>().getName();
        inventory.Add(item);
        evidence.Add(itemName);
        allFlags.Add("has" + itemName, true);

        string ledgerName = "Ledger";
        string bankstatementName = "BankStatement";
        if (allFlags.ContainsKey("has" + ledgerName) && allFlags.ContainsKey("has" + bankstatementName))
        {
            if (!allFlags.ContainsKey("has" + ledgerName + "&" + bankstatementName))
            {
                allFlags.Add("has" + ledgerName + "&" + bankstatementName, true);
            }
        }
    }

    public void addTestimony(string testimonyID, string testimonyContents, GameObject character)
    {
        if (!testimony.ContainsKey(testimonyID))
        {
            testimony.Add(testimonyID, testimonyContents);
            evidence.Add(testimonyID);
            allFlags.Add("heard" + testimonyID, true);

            if (characterToTestimony.ContainsKey(gameObject))
            {
                var t = characterToTestimony[character];
                t.Add(testimonyID);

                characterToTestimony.Add(character, t);
            }
            else
            {
                List<string> t = new List<string>();
                t.Add(testimonyID);
                characterToTestimony.Add(character, t);
            }
        }
        Debug.Log(testimonyID + " added to Notebook");
    }

    public void accusationBegin()
    {
        presentedEvidence.Clear();
        accusing = true;
    }

    public void presentEvidence(string evidence, GameObject character)
    {
        if (presentedEvidence.Contains(evidence))
        {
            currentAccuseDialogue = "I've already used that";
        }
        else
        {
            if (accuseDialogue[character].ContainsKey(evidence))
            {
                currentAccuseDialogue = accuseDialogue[character][evidence];
                float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()];
                character.GetComponent<CharacterInfo>().increasePressure(p);
                presentedEvidence.Add(evidence);
            }
            else
            {
                currentAccuseDialogue = "THIS PROVES IT WAS YOU!!! ... oh ... ummm ... maybe not...";
                character.GetComponent<CharacterInfo>().decreasePressure(-1);
                presentedEvidence.Add(evidence);
            }
        }

    }

    public void loseLife()
    {
        lives--;
        if (lives == 0)
        {
            //game over
        }
    }

}
