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
    Dictionary<string, Dictionary<string, string>> accuseDialogue;
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
        //character -> evidence -> explanation
        accuseDialogue = new Dictionary<string, Dictionary<string, string>>();
        //

        Dictionary<string, string> spouseEvidence = new Dictionary<string, string>();
        Dictionary<string, string> maidEvidence = new Dictionary<string, string>();
        Dictionary<string, string> butlerEvidence = new Dictionary<string, string>();
        Dictionary<string, string> chefEvidence = new Dictionary<string, string>();
        Dictionary<string, string> guestEvidence = new Dictionary<string, string>();
        Dictionary<string, string> partnerEvidence = new Dictionary<string, string>();

        string staffBreak = @"You knew the staff would be on break, which means you knew no one would be attending to Heather.";
        string butlerBreak = @"You knew the upper floor, where the Master Bedroom is would not have anyone attending.";
        string hostNecklace = @"Heather's necklace being stolen provides finacial motive for a servant to kill her.";
        string butlerRounds = @"There are servant passages that can be used to move undetected.
                               Household members and staff would have been familiar with them.";
        string kitchenOthers = @"As a servant, you could have easily entered the Kitchen and obtained the Knife
                                    without drawing attention.";
        string knifeSource = @"The murder weapon was from the Kitchen meaning that anyone in the house could have access to it.";
        string hostTiming = @"The Host was feeling unwell and left first. It would have only been known to those in the Parlour
                            that she left by herself since the servants were not at their posts.";
        string speakingTube = @"There is a Speaking Tube located in the Master Bedroom as well as the Servants Quarters.
                              Heather, feeling unwell, could have requested assistance using it.
                              Since you were in the Servants' Quarters at the time, you could have heard her and learned she was
                              in the Master Bedroom alone.";
        string chefLocation = @"Chef mentioned leaving the Kitchen briefly, which would give non-staff a window to access the Knife.";
        butlerEvidence.Add(
            "ButlerLocation", 
            @"Your nightly rounds give you plenty of opportunity to murder Heather.
            Also, because you were outside the Parlour, you could have seen Heather leave early.");
        butlerEvidence.Add(
            "StaffBreak",
             staffBreak);
        butlerEvidence.Add(
            "Butlerbreak",
            butlerBreak +
            @"It is suspicious that you decided to complete your rounds despite being told to rest.");
        butlerEvidence.Add(
            "HostNecklace",
            hostNecklace);
        butlerEvidence.Add(
            "ButlerEvidence",
            butlerRounds);
        butlerEvidence.Add(
            "ChefThoughts",
            @"The Chef claims that you may have been frustrated with how your employers were treating you");
        butlerEvidence.Add(
            "KitchenOthers",
            kitchenOthers);
        butlerEvidence.Add(
            "KnifeSource",
            knifeSource + @"Chef in particular would have the greatest opportunity to take the Knife.");


        spouseEvidence.Add(
            "StaffBreak", staffBreak);
        spouseEvidence.Add(
            "SpouseLocation",
            @"After leaving the Parlour, you left for the Study by yourself which means you have no alibi."
            );
        spouseEvidence.Add(
            "ButlerRounds",
            butlerRounds);
        spouseEvidence.Add(
            "Ledger", 
            @"There is proof you have commited embezzlment in your home. There is the possibility that Heather knew
            and would be responsible for you being caught.");
        spouseEvidence.Add(
            "BankStatement",
            @"This bank statement shows that recently life insurance was aquired for Heather.");
        spouseEvidence.Add(
            "HostTiming", hostTiming);
        spouseEvidence.Add(
            "KnifeSource",
            knifeSource);
        spouseEvidence.Add(
            "GuestLoveLettersMutual",
            @"Agnes behaviour suggests you were having an affair with her.");
        spouseEvidence.Add(
            "KitchenOthers",
            @"Although you are not a servant, it is still your house so you might not draw attention in the Kitchen when taking the Knife.");
        spouseEvidence.Add(
            "NoticeOfDismissal",
            @"You have recently lost a well paying career. Margaret claims Heather was very upset by this.
            It is possible you feared that she would divorce you and you were not willing to give up you wealthy lifestyle.");
        spouseEvidence.Add(
            "Firing",
            @"You have recently lost a well paying career. Margaret claims Heather was very upset by this.
            It is possible you feared that she would divorce you and you were not willing to give up you wealthy lifestyle.");
        spouseEvidence.Add(
            "Newspaper",
            @"This newspaper demonstrates there has been a history of embezzlement at your company whilst you were employed there.
            A career criminal cannot be trusted!!!!");

        maidEvidence.Add(
            "StaffBreak", staffBreak);
        maidEvidence.Add(
            "ButlerBreak", butlerBreak);
        maidEvidence.Add("HostNecklace", hostNecklace);
        maidEvidence.Add("ButlerRounds", butlerRounds);
        maidEvidence.Add("KnifeSource", knifeSource);
        maidEvidence.Add("KitchenOthers", kitchenOthers);
        maidEvidence.Add("SpeakingTube",speakingTube);
        maidEvidence.Add("MaidFamilyPhoto",
            @"This is photo and this newspaper show that Margaret is related to someone you used to work at 
            Silvia's company before being fired for embezzlement.
            We have also learned that Silvia has been commiting embezzlement.
            It is possible Silvia was responsible in the past too and framed Margaret's relative.
            Margaret killed Heather out of revenge because she and Silvia were able to live luxeriously at the expense of
            Margaret's family");
        maidEvidence.Add("Newspaper",
            @"This is photo and this newspaper show that Margaret is related to someone you used to work at 
            Silvia's company before being fired for embezzlement.
            We have also learned that Silvia has been commiting embezzlement.
            It is possible Silvia was responsible in the past too and framed Margaret's relative.
            Margaret killed Heather out of revenge because she and Silvia were able to live luxeriously at the expense of
            Margaret's family");

        chefEvidence.Add("StaffBreak", staffBreak);
        chefEvidence.Add("ButlerBreak", butlerBreak);
        chefEvidence.Add("HostNecklace", hostNecklace);
        chefEvidence.Add("ChefLocation",
            @"You claimed to be in the Kitchen before your break. This gives you opportunity to take the Knife and kill Heather");
        chefEvidence.Add("ButlerRounds", butlerRounds);
        chefEvidence.Add("KnifeSource", knifeSource);
        chefEvidence.Add("KitchenOthers", kitchenOthers);
        chefEvidence.Add("SpeakingTube", speakingTube);

        guestEvidence.Add("HostNecklace",
            @"Although Heather's necklace would not provide Agnes with finacial incentive, 
            taking the necklace could have been out of an act of jeaslousy");
        guestEvidence.Add("GuestHostLove",
            @"Agnes likely saw Heather as an obstacle to her being with Silvia");
        guestEvidence.Add("ChefLocation", chefLocation);
        guestEvidence.Add("HostTiming", hostTiming);
        guestEvidence.Add("KnifeSource", knifeSource);
        guestEvidence.Add("GuestLoveLettersMutual",
            @"Agnes refuses to deny that Silvia does not reciprocate her feelings.
            This means she could have seen Heather as being the obstacle between her and Silvia.");
        guestEvidence.Add("LoveLetters",
            @"These Love Letters from Agnes to Silvia show she has a deep infatuation with her and was likely jeaslous of Heather");


        partnerEvidence.Add("ChefLocation", chefLocation);
        partnerEvidence.Add("HostTiming", hostTiming);
        partnerEvidence.Add("GuestLocation",
            @"Although Agnes was also in the Parlour, her level of intoxication makes her an unreliable alibi for Bernard.");
        partnerEvidence.Add("KnifeSource", knifeSource);
        partnerEvidence.Add("GuestSharesReaction",
            @"According to Agnes, Bernard was enraged that Heather would not be bought out of their company. Bernard would gain Heather's shares upon her death");

        accuseDialogue.Add("Silvia", spouseEvidence);
        accuseDialogue.Add("Margaret", maidEvidence);
        accuseDialogue.Add("Bartholomew", butlerEvidence);
        accuseDialogue.Add("Chef", chefEvidence);
        accuseDialogue.Add("Agnes", guestEvidence);
        accuseDialogue.Add("Bernard", partnerEvidence);

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

        Debug.Log(item.GetComponent<ItemInfo>().getName() + " picked up protag");
    }

    public void addTestimony(string testimonyID, string testimonyContents, GameObject character)
    {
        if (!testimony.ContainsKey(testimonyID))
        {
            testimony.Add(testimonyID, testimonyContents);
            evidence.Add(testimonyID);
            allFlags.Add("heard" + testimonyID, true);

            if (characterToTestimony.ContainsKey(character))
            {
                var t = characterToTestimony[character];
                t.Add(testimonyID);

                characterToTestimony[character] = t;
                //characterToTestimony.Add(character, t);
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
            if (accuseDialogue[character.GetComponent<CharacterInfo>().getName()].ContainsKey(evidence))
            {

                //ledger req bank statement
                if (evidence == "BankStatement" && !presentedEvidence.Contains("Ledger"))
                {
                    currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                    float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()];
                    character.GetComponent<CharacterInfo>().increasePressure(p);
                    presentedEvidence.Add(evidence);
                }
                else if (evidence == "BankStatement")
                {
                    //currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                    currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()]["Ledger"];
                    float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()] + EvidenceMasterList.evidenceToCharacters["Ledger"][character.GetComponent<CharacterInfo>().getName()];
                    character.GetComponent<CharacterInfo>().increasePressure(p);
                    presentedEvidence.Add(evidence);
                }

                else if(evidence == "Ledger")
                {
                    if (presentedEvidence.Contains("BankStatement"))
                    {
                        currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                        float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()];
                        character.GetComponent<CharacterInfo>().increasePressure(p);
                        presentedEvidence.Add(evidence);
                    }
                    else
                    {
                        if (allFlags.ContainsKey("hasBankStatement"))
                        {
                            currentAccuseDialogue = @"This is will be useful but I need to present another piece of evidence for it to be effective";
                        }
                        else
                        {
                            currentAccuseDialogue = "THIS PROVES IT WAS YOU!!! ... oh ... ummm ... maybe not...";
                            character.GetComponent<CharacterInfo>().decreasePressure(-1);
                        }
                        presentedEvidence.Add(evidence);
                    }
                }

                //maid family photo and newspaper (and embezzlement)

                else if (evidence == "Newspaper")
                {
                    if (!allFlags.ContainsKey("hasMaidFamilyPhoto"))
                    {
                        currentAccuseDialogue = "THIS PROVES IT WAS YOU!!! ... oh ... ummm ... maybe not...";
                        character.GetComponent<CharacterInfo>().decreasePressure(-1);
                    }
                    else if (!allFlags.ContainsKey("hasLedger&BankStatement") && presentedEvidence.Contains("MaidFamilyPhoto"))
                    {
                        currentAccuseDialogue = @"This newspaper and photo of the maids family show that she had a relative who was caught embezzeling from Silvia's company and it became a scandle.
                                                Silvia spoke out against this person despite their friendship so Margaret was seeking revenge.";
                    }

                    else if (!presentedEvidence.Contains("MaidFamilyPhoto"))
                    {
                        currentAccuseDialogue = @"This is will be useful but I need to present another piece of evidence for it to be effective";
                    }

                    else
                    {
                        currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                        float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()] + EvidenceMasterList.evidenceToCharacters["MaidFamilyPhoto"][character.GetComponent<CharacterInfo>().getName()];
                        character.GetComponent<CharacterInfo>().increasePressure(p);
                    }

                    presentedEvidence.Add(evidence);
                }
                else if (evidence == "MaidFamilyPhoto")
                {
                    if (!allFlags.ContainsKey("hasNewspaper"))
                    {
                        currentAccuseDialogue = "THIS PROVES IT WAS YOU!!! ... oh ... ummm ... maybe not...";
                        character.GetComponent<CharacterInfo>().decreasePressure(-1);
                    }
                    else if (!allFlags.ContainsKey("hasLedger&BankStatement") && presentedEvidence.Contains("Newspaper"))
                    {
                        currentAccuseDialogue = @"This newspaper and photo of the maids family show that she had a relative who was caught embezzeling from Silvia's company and it became a scandle.
                                                Silvia spoke out against this person despite their friendship so Margaret was seeking revenge.";
                    }
                    else if (!presentedEvidence.Contains("Newspaper"))
                    {
                        currentAccuseDialogue = @"This is will be useful but I need to present another piece of evidence for it to be effective";
                    }
                    else
                    {
                        currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                        float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()] + EvidenceMasterList.evidenceToCharacters["Newspaper"][character.GetComponent<CharacterInfo>().getName()];
                        character.GetComponent<CharacterInfo>().increasePressure(p);
                    }

                    presentedEvidence.Add(evidence);
                }

                else
                {
                    currentAccuseDialogue = accuseDialogue[character.GetComponent<CharacterInfo>().getName()][evidence];
                    float p = EvidenceMasterList.evidenceToCharacters[evidence][character.GetComponent<CharacterInfo>().getName()];
                    character.GetComponent<CharacterInfo>().increasePressure(p);
                    presentedEvidence.Add(evidence);
                }
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
