using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBookshelf : MonoBehaviour
{
    public GameObject book;
    public Vector3 newPosition;
    public int secretPage;
    public float moveTime;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!book.GetComponent<SpriteRenderer>().enabled && book.GetComponent<BookManager>().currentPage == secretPage)
        {
            canMove = true;
        }

        if (canMove)
        {
            transform.position += (newPosition-transform.position)*Time.deltaTime/moveTime;
        }
    }
}
