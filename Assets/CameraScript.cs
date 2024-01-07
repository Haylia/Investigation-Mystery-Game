using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Protag").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // find player x value
        if (player)
        {
            //TODO:
            //lock player Y to one of the three floors
            float playerx = player.transform.position.x;
            float playery = player.transform.position.y;
            Vector3 targetPosition = new Vector3(playerx, playery + 5, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 5f * Time.deltaTime);
        }
    }
}
