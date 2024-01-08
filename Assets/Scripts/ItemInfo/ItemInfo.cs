using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo : MonoBehaviour
{
    public abstract bool getCanPickUp();
    public abstract void setCanPickUp(bool b);
    public abstract string getName();

    public abstract Dictionary<string, string> getAllInspect();

    public abstract Dictionary<string, string> getAllCombine();

    public abstract Dictionary<string, bool> getAllFlags();

    public abstract void setFlag(string flag, bool b);


}
