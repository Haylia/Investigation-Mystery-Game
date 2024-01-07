using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bcollider;
    SpriteRenderer sr;
    private float movementX;
    private float movementY;
    public float movementSpeed;
    GameObject stairsup1;
    GameObject stairsup2;
    GameObject stairsdown1;
    GameObject stairsdown2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bcollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        stairsup1 = GameObject.Find("Stairs Up 1");
        stairsup2 = GameObject.Find("Stairs Up 2");
        stairsdown1 = GameObject.Find("Stairs Down 1");
        stairsdown2 = GameObject.Find("Stairs Down 2");
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    // Update is called once per frame
    void Update()
    {
        // move left and right
        movementY = 0;
        rb.velocity = new Vector3(movementX*movementSpeed, movementY*movementSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided with " + collision.name);
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space clicked");
            if (collision.gameObject.layer == LayerMask.NameToLayer("Stairs"))
            {
                UseStairs(collision.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space clicked");
            if (collision.gameObject.layer == LayerMask.NameToLayer("Stairs"))
            {
                UseStairs(collision.gameObject);
            }
        }

    }

    void UseStairs(GameObject gameObject)
    {

        if (gameObject == stairsup1 || gameObject == stairsup2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
        if (gameObject == stairsdown1 || gameObject == stairsdown2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        }
    }
}
