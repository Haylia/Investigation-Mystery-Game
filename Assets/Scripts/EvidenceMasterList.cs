using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EvidenceMasterList
{
    //holds all evidence, characters affective against and score

    static public List<string> evidence = new List<string>();
    static public Dictionary<string, Dictionary<string, float>> evidenceToCharacters = new Dictionary<string, Dictionary<string, float>>();
    static public Dictionary<string, int> character_1 = new Dictionary<string, int>();
}
