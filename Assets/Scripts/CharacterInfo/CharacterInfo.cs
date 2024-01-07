using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterInfo : MonoBehaviour
{
    public abstract string getName();

    public abstract string getDefaultShow();
    public abstract string getAccuseAgain();

    public abstract Dictionary<string, Dictionary<string, string>> getAllTalk();

    public abstract Dictionary<string, List<string>> getFlagToDialogueOptions();

    public abstract Dictionary<string, string> getAvailableTalk();

    public abstract Dictionary<string, string> getAllShow();

    public abstract Dictionary<string, string> getTestimonyToID();
    public abstract Dictionary<string, string> getIDToTestimony();

    public abstract Dictionary<string, bool> getAllFlags();

    public abstract void setFlag(string flag, bool b);

    public abstract float getPressure();

    public abstract Dictionary<int, string> getPressureResponse();

    public abstract void increasePressure(float p);
    public abstract void decreasePressure(float p);
    public abstract void setPressure(float p);

    public abstract void setAccused(bool b);
    public abstract bool getAccused();

    public abstract void setSuccessful(bool b);
    public abstract bool getSuccessful();
}

