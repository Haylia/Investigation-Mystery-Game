using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HouseLighting : MonoBehaviour
{
    // define the shade for the map
    //make it dark  in the rest of the rooms
    // identify the label for the room

    Transform player;
    TMPro.TextMeshProUGUI tmp;
    GameObject roomtextobj;
    GameObject foyerShaderObj;
    GameObject parlourShaderObj;
    GameObject diningShaderObj;
    GameObject libraryShaderObj;
    GameObject loungeShaderObj;
    GameObject pantryShaderObj;
    GameObject kitchenShaderObj;
    GameObject chefShaderObj;
    GameObject maidShaderObj;
    GameObject butlerShaderObj;
    GameObject childShaderObj;
    GameObject hostShaderObj;
    GameObject guest1ShaderObj;
    GameObject studyShaderObj;
    GameObject guest2ShaderObj;
    string textstring;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Protag").transform;
        roomtextobj = GameObject.Find("RoomText");
        tmp = roomtextobj.GetComponent<TMPro.TextMeshProUGUI>();
        foyerShaderObj = GameObject.Find("Foyer Room Shade");
        parlourShaderObj = GameObject.Find("Parlour Room Shade");
        diningShaderObj = GameObject.Find("Dining Room Shade");
        libraryShaderObj = GameObject.Find("Library Room Shade");
        loungeShaderObj = GameObject.Find("Lounge Room Shade");
        pantryShaderObj = GameObject.Find("Pantry Room Shade");
        kitchenShaderObj = GameObject.Find("Kitchen Room Shade");
        chefShaderObj = GameObject.Find("Chefs Room Shade");
        maidShaderObj = GameObject.Find("Maids Room Shade");
        butlerShaderObj = GameObject.Find("Butlers Room Shade");
        childShaderObj = GameObject.Find("Child Room Shade");
        hostShaderObj = GameObject.Find("Host Room Shade");
        guest1ShaderObj = GameObject.Find("Guest 1 Room Shade");
        studyShaderObj = GameObject.Find("Study Room Shade");
        guest2ShaderObj = GameObject.Find("Guest 2 Room Shade");
    }

    // Update is called once per frame
    void Update()
    {
        // find player x value
        if (player)
        {
            float playerx = player.transform.position.x;
            float playery = player.transform.position.y;
            // Debug.Log("player x: " + playerx.ToString()  + " player y: "+ playery.ToString());
            if(playerx > -77 && playerx < -47  && playery > 20 && playery < 40)
            {
                //foyer
                foyerShaderObj.SetActive(false);
                tmp.text = "Room: Foyer";
                //Debug.Log("In Foyer");
            }
            else
            {
                foyerShaderObj.SetActive(true);
            }
            if (playerx > -47 && playerx < -17 && playery > 20 && playery < 40)
            {
                //parlour
                parlourShaderObj.SetActive(false);
                tmp.text = "Room: Parlour";
                //Debug.Log("In Parlour");
            }
            else
            {
                parlourShaderObj.SetActive(true);
            }
            if (playerx > -17 && playerx < 14 && playery > 20 && playery < 40)
            {
                //dining room
                diningShaderObj.SetActive(false);
                tmp.text = "Room: Dining Room";
                //Debug.Log("In Dining Room");
            }
            else
            {
                diningShaderObj.SetActive(true);
            }
            if (playerx > 14 && playerx < 44 && playery > 20 && playery < 40)
            {
                //library
                libraryShaderObj.SetActive(false);
                tmp.text = "Room: Library";
                //Debug.Log("In Foyer");
            }
            else
            {
                libraryShaderObj.SetActive(true);
            }
            if (playerx > 44 && playerx < 74 && playery > 20 && playery < 40)
            {
                //lounge
                loungeShaderObj.SetActive(false);
                tmp.text = "Room: Lounge";
                //Debug.Log("In Lounge");
            }
            else
            {
                loungeShaderObj.SetActive(true);
            }
            if (playerx > -77 && playerx < -47 && playery > 0 && playery < 20)
            {
                //pantry
                pantryShaderObj.SetActive(false);
                tmp.text = "Room: Pantry";
                //Debug.Log("In Pantry");
            }
            else
            {
                pantryShaderObj.SetActive(true);
            }
            if (playerx > -47 && playerx < -17 && playery > 0 && playery < 20)
            {
                //kitchen
                kitchenShaderObj.SetActive(false);
                tmp.text = "Room: Kitchen";
                //Debug.Log("In Kitchen");
            }
            else
            {
                kitchenShaderObj.SetActive(true);
            }
            if (playerx > -17 && playerx < 14 && playery > 0 && playery < 20)
            {
                //chef
                chefShaderObj.SetActive(false);
                tmp.text = "Room: Chef's Quarters";
                //Debug.Log("In Chefs");
            }
            else
            {
                chefShaderObj.SetActive(true);
            }
            if (playerx > 14 && playerx < 44 && playery > 0 && playery < 20)
            {
                //maid
                maidShaderObj.SetActive(false);
                tmp.text = "Room: Maid's Quarters";
                //Debug.Log("In Maids");
            }
            else
            {
                maidShaderObj.SetActive(true);
            }
            if (playerx > 44 && playerx < 74 && playery > 0 && playery < 20)
            {
                //butler
                butlerShaderObj.SetActive(false);
                tmp.text = "Room: Butler's Quarters";
                //Debug.Log("In Butlers");
            }
            else
            {
                butlerShaderObj.SetActive(true);
            }
            if (playerx > -77 && playerx < -47 && playery > 40 && playery < 60)
            {
                //child room
                childShaderObj.SetActive(false);
                tmp.text = "Room: Child's Room";
                //Debug.Log("In Childs");
            }
            else
            {
                childShaderObj.SetActive(true);
            }
            if (playerx > -47 && playerx < -17 && playery > 40 && playery < 60)
            {
                //host room
                hostShaderObj.SetActive(false);
                tmp.text = "Room: Host's Bedroom";
                //Debug.Log("In Hosts");
            }
            else
            {
                hostShaderObj.SetActive(true);
            }
            if (playerx > -17 && playerx < 14 && playery > 40 && playery < 60)
            {
                //guest room 1
                guest1ShaderObj.SetActive(false);
                tmp.text = "Room: Guest Bedroom 1";
                //Debug.Log("In Guest room 1");
            }
            else
            {
                guest1ShaderObj.SetActive(true);
            }
            if (playerx > 14 && playerx < 44 && playery > 40 && playery < 60)
            {
                //study
                studyShaderObj.SetActive(false);
                tmp.text = "Room: Study";
                //Debug.Log("In Study");
            }
            else
            {
                studyShaderObj.SetActive(true);
            }
            if (playerx > 44 && playerx < 74 && playery > 40 && playery < 60)
            {
                //guest room 2
                guest2ShaderObj.SetActive(false);
                tmp.text = "Room: Guest Bedroom 2";
                //Debug.Log("In Guest room 2");
            }
            else
            {
                guest2ShaderObj.SetActive(true);
            }
        }
    }
}
