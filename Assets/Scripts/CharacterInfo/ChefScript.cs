using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefScript : CharacterInfo
{
    string characterName = "Chef";

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
        allShow.Add("Knife", TestimonyMasterList.KnifeSource);

        idToTestimony.Add("ChefIntro", TestimonyMasterList.ChefIntro);
        idToTestimony.Add("ChefHost", TestimonyMasterList.ChefHost);
        idToTestimony.Add("ChefLocation", TestimonyMasterList.ChefLocation);
        idToTestimony.Add("ChefThoughts", TestimonyMasterList.ChefThoughts);
        idToTestimony.Add("KnifeLocation", TestimonyMasterList.KnifeLocation);
        idToTestimony.Add("KitchenOthers", TestimonyMasterList.KitchenOthers);

        foreach (KeyValuePair<string, string> entry in idToTestimony)
        {
            testimonyToID.Add(entry.Value, entry.Key);
        }

        Dictionary<string, string> def0 = new Dictionary<string, string>();
        Dictionary<string, string> def1 = new Dictionary<string, string>();
        Dictionary<string, string> def2 = new Dictionary<string, string>();
        Dictionary<string, string> def3 = new Dictionary<string, string>();
        Dictionary<string, string> knife0 = new Dictionary<string, string>();
        Dictionary<string, string> knife1 = new Dictionary<string, string>();

        def0.Add("default", "ChefIntro");
        def1.Add("default", "ChefHost");
        def2.Add("default", "ChefLocation");
        def3.Add("default", "ChefThoughts");
        knife0.Add("default", "KnifeLocation");
        knife1.Add("default", "KitchenOthers");

        allDialogue.Add(TestimonyMasterList.ChefDefIntro, def0);
        allDialogue.Add(TestimonyMasterList.ChefDefHost, def1);
        allDialogue.Add(TestimonyMasterList.ChefDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.ChefDefThoughts, def3);
        allDialogue.Add(TestimonyMasterList.ChefKnifeLocation, knife0);
        allDialogue.Add(TestimonyMasterList.ChefKitchenOthers, knife1);

        List<string> defaultOps = new List<string>();
        List<string> knifeOps = new List<string>();

        defaultOps.Add(TestimonyMasterList.ChefDefIntro);
        defaultOps.Add(TestimonyMasterList.ChefDefHost);
        defaultOps.Add(TestimonyMasterList.ChefDefLocation);
        defaultOps.Add(TestimonyMasterList.ChefDefThoughts);
        knifeOps.Add(TestimonyMasterList.ChefKnifeLocation);
        knifeOps.Add(TestimonyMasterList.ChefKitchenOthers);

        flagToDialogueOptions.Add("default", defaultOps);
        flagToDialogueOptions.Add("shownKnife", knifeOps);

        pressureResponse.Add(0, "You have no evidence pointing to me");
        pressureResponse.Add(1, "It's just a misunderstanding, you can see that. That by itself doesn't really prove anything anyway");
        pressureResponse.Add(2, "You have it all wrong, I can explain!");
        pressureResponse.Add(3, "Ahem... it looks bad for me... but I maintain my innocence!");
        pressureResponse.Add(4, "I won't stand for this! This is ridiculous!");
        pressureResponse.Add(5, "I feel so exposed... but I didn't do it!");
        pressureResponse.Add(6, "Oh god... surely some of this stuff is planted..."); ;
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
