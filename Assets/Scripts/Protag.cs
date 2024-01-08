using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Protag : MonoBehaviour
{
    private GameObject notebook;
    private GameObject inventory;
    private GameObject menu;
    private GameObject explain;

    private GameObject canvas;


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
    public AudioSource sfxSrc;

    // Start is called before the first frame update
    void Start()
    {
        notebook = transform.Find("ProtagCanvas/Notebook").gameObject;
        notebook.SetActive(false);
        inventory = transform.Find("ProtagCanvas/Inventory").gameObject;
        inventory.SetActive(false);
        menu = transform.Find("ProtagCanvas/ProtagMenu").gameObject;
        //menu.SetActive(false);
        explain = transform.Find("ProtagCanvas/ExplainCanvas").gameObject;
        //explain.SetActive(false);

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
        rb.velocity = new Vector3(movementX * movementSpeed, movementY * movementSpeed);

    }

    private void OnMouseDown()
    {
        sfxSrc.PlayOneShot(sfxSrc.clip, 0.8f);
        openMenu();
    }

    public void openNotebook()
    {
        notebook.SetActive(true);
        notebook.GetComponent<Notebook>().onOpen();
    }

    public void closeNotebook()
    {
        notebook.SetActive(false);
    }

    public void openInventory()
    {
        inventory.SetActive(true);
        inventory.GetComponent<Inventory>().onOpen();
    }

    public void closeInventory()
    {
        inventory.SetActive(false);
    }

    public void openMenu()
    {
        menu.SetActive(true);
    }

    public void closeMenu()
    {
        menu.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided with " + collision.name);
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        if (Input.GetKey(KeyCode.Space))
        {
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
            if (collision.gameObject.layer == LayerMask.NameToLayer("Stairs"))
            {
                UseStairs(collision.gameObject);
            }
        }

    }

    void UseStairs(GameObject gameObject)
    {
        sfxSrc.PlayOneShot(sfxSrc.clip, 0.8f);
        if (gameObject == stairsup1 || gameObject == stairsup2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
        }
        if (gameObject == stairsdown1 || gameObject == stairsdown2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
        }
    }
}