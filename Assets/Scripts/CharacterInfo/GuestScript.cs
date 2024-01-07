using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestScript : CharacterInfo
{
    string characterName = "Agnes";

    bool accused = false;
    bool successful = false;


    float pressure = 0;
    //character dialogue used in accusation
    Dictionary<int, string> pressureResponse = new Dictionary<int, string>();

    //dialogue option to dict of flag to responses
    //each dialogue option has multiple responses depending on flags
    //op -> flag -> res
    Dictionary<string, Dictionary<string, string>> allDialogue = new Dictionary<string, Dictionary<string, string>>();

    //dialogue options are available depending on flags
    //flag -> ops
    Dictionary<string, List<string>> flagToDialogueOptions = new Dictionary<string, List<string>>();
    //op -> res
    Dictionary<string, string> availableDialogue = new Dictionary<string, string>();

    //show an item only has one response for each item
    Dictionary<string, string> allShow = new Dictionary<string, string>();

    Dictionary<string, string> idToTestimony = new Dictionary<string, string>();
    Dictionary<string, string> testimonyToID = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {
        //pressure response

        //show
        allShow.Add("LoveLetters", TestimonyMasterList.GuestLoveLetters);

        idToTestimony.Add("GuestIntro", TestimonyMasterList.GuestIntro);
        idToTestimony.Add("GuestHostDefault", TestimonyMasterList.GuestHostDefault);
        idToTestimony.Add("GuestHostLove", TestimonyMasterList.GuestHostLove);
        idToTestimony.Add("GuestLocation", TestimonyMasterList.GuestLocation);
        idToTestimony.Add("GuestThoughts", TestimonyMasterList.GuestThoughts);
        idToTestimony.Add("GuestLoveLettersHost", TestimonyMasterList.GuestLoveLettersHost);
        idToTestimony.Add("GuestLoveLettersMutual", TestimonyMasterList.GuestLoveLettersMutual);
        idToTestimony.Add("GuestSharesReason", TestimonyMasterList.GuestSharesReason);
        idToTestimony.Add("GuestSharesReaction", TestimonyMasterList.GuestSharesReaction);

        Dictionary<string, string> def0 = new Dictionary<string, string>();
        Dictionary<string, string> def1 = new Dictionary<string, string>();
        Dictionary<string, string> def2 = new Dictionary<string, string>();
        Dictionary<string, string> def3 = new Dictionary<string, string>();
        Dictionary<string, string> love0 = new Dictionary<string, string>();
        Dictionary<string, string> love1 = new Dictionary<string, string>();
        Dictionary<string, string> shares0 = new Dictionary<string, string>();
        Dictionary<string, string> shares1 = new Dictionary<string, string>();

        def0.Add("default", "GuestIntro");
        def1.Add("default", "GuestHostDefault");
        def1.Add("shownLoveLetters", "GuestHostLove");
        def2.Add("default", "GuestLocation");
        def3.Add("default", "GuestThoughts");
        love0.Add("default", "GuestLoveLettersHost");
        love1.Add("default", "GuestLoveLettersMutual");
        shares0.Add("default", "GuestSharesReason");
        shares1.Add("default", "GuestSharesReaction");

        allDialogue.Add(TestimonyMasterList.GuestDefIntro, def0);
        allDialogue.Add(TestimonyMasterList.GuestDefHost, def1);
        allDialogue.Add(TestimonyMasterList.GuestDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.GuestDefThoughts, def3);
        allDialogue.Add(TestimonyMasterList.GuestHostKnow, love0);
        allDialogue.Add(TestimonyMasterList.GuestMutual, love1);
        allDialogue.Add(TestimonyMasterList.GuestSharesWhy, shares0);
        allDialogue.Add(TestimonyMasterList.GuestSharesPartner, shares1);

        List<string> defaultOps = new List<string>();
        defaultOps.Add(TestimonyMasterList.GuestDefIntro);
        defaultOps.Add(TestimonyMasterList.GuestDefHost);
        defaultOps.Add(TestimonyMasterList.GuestDefLocation);
        defaultOps.Add(TestimonyMasterList.GuestDefThoughts);
        List<string> loveOps = new List<string>();
        loveOps.Add(TestimonyMasterList.GuestHostKnow);
        loveOps.Add(TestimonyMasterList.GuestMutual);
        List<string> sharesOps = new List<string>();
        sharesOps.Add(TestimonyMasterList.GuestSharesWhy);
        sharesOps.Add(TestimonyMasterList.GuestSharesPartner);

        flagToDialogueOptions.Add("default", defaultOps);
        flagToDialogueOptions.Add("shownLoveLetters", loveOps);
        flagToDialogueOptions.Add("heardSpousePartner", sharesOps);
    }

    public override string getDefaultShow()
    {
        return "Default show";
    }

    public override string getAccuseAgain()
    {
        return "I've already been accused";
    }


    //keep same

    public override string getName()
    {
        return characterName;
    }

    override public Dictionary<string, Dictionary<string, string>> getAllTalk()
    {
        return allDialogue;
    }

    public override Dictionary<string, List<string>> getFlagToDialogueOptions()
    {
        return flagToDialogueOptions;
    }

    override public Dictionary<string, string> getAvailableTalk()
    {
        return availableDialogue;
    }

    override public Dictionary<string, string> getAllShow()
    {
        return allShow;
    }

    override public Dictionary<string, string> getTestimonyToID()
    {
        return testimonyToID;
    }

    override public Dictionary<string, string> getIDToTestimony()
    {
        return idToTestimony;
    }

    public override Dictionary<string, bool> getAllFlags()
    {
        return allFlags;
    }

    override public void setFlag(string flag, bool b)
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

    override public float getPressure()
    {
        return pressure;
    }

    override public Dictionary<int, string> getPressureResponse()
    {
        return pressureResponse;
    }

    public override void increasePressure(float p)
    {
        pressure += p;
    }

    public override void decreasePressure(float p)
    {
        pressure -= p;

    }

    public override void setPressure(float p)
    {
        pressure = 0;
    }

    public override void setAccused(bool b)
    {
        accused = b;
    }

    public override bool getAccused()
    {
        return accused;
    }

    public override void setSuccessful(bool b)
    {
        successful = b;
    }

    public override bool getSuccessful()
    {
        return successful;
    }
}
