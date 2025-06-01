using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XManager : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public GameObject calendar;
    public string mouseTag;
    public string hoverTag;
    public GameObject mouse;
    public bool on = false;

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
        if (calendar.GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;

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

            if (on)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[3];
            } else
            {
                GetComponent<SpriteRenderer>().sprite = sprites[0];
            }

            for (int index = 0; index < results.Count; index++)
            {
                if (results[index].tag == hoverTag)
                {
                    if (on)
                    {
                        GetComponent<SpriteRenderer>().sprite = sprites[2];
                    } else
                    {
                        GetComponent<SpriteRenderer>().sprite = sprites[1];
                    }
                }
            }

            if (isClicked && !wasClicked)
            {
                on = !on;
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
        wasClicked = mouse.GetComponent<Collider2D>().enabled;
    }
}
