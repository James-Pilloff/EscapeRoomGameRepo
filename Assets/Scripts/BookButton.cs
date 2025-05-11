using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    public GameObject book;
    public GameObject mouse;
    public string interaction;
    public string mouseTag;

    private bool wasClicked;
    private bool isClicked;
    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(Physics2D.AllLayers);
        contactFilter.useLayerMask = true;
        isClicked = false;
        wasClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        isClicked = false;

        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == mouseTag)
            {
                isClicked = true;
            }
        }

        if (isClicked && !wasClicked)
        {
            if (interaction == "next")
            {
                book.GetComponent<BookManager>().NextPage();
            } else
            {
                book.GetComponent<BookManager>().PreviousPage();
            }
        }

        if (book.GetComponent<SpriteRenderer>().enabled)
        {
            if (interaction == "next")
            {
                GetComponent<SpriteRenderer>().enabled = book.GetComponent<BookManager>().currentPage != book.GetComponent<BookManager>().bookLength-1;
                GetComponent<Collider2D>().enabled = book.GetComponent<BookManager>().currentPage != book.GetComponent<BookManager>().bookLength-1;
            } else
            {
                GetComponent<SpriteRenderer>().enabled = book.GetComponent<BookManager>().currentPage != 0;
                GetComponent<Collider2D>().enabled = book.GetComponent<BookManager>().currentPage != 0;
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        wasClicked = mouse.GetComponent<Collider2D>().enabled;
    }
}
