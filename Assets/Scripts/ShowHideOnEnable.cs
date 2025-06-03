using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOnEnable : MonoBehaviour
{
    public List<GameObject> startsShown = new List<GameObject>();
    public string mouseTag;
    public GameObject mouse;
    public Vector3 start;
    public Vector3 end;
    public Sprite startImage;
    public Sprite endImage;

    private bool wasClicked;
    private bool isClicked;
    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();
    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        state = true;
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
            state = !state;
        }

        wasClicked = mouse.GetComponent<Collider2D>().enabled;

        for (int index = 0; index < startsShown.Count; index++)
        {
            startsShown[index].GetComponent<SpriteRenderer>().enabled = state;
            startsShown[index].GetComponent<Collider2D>().enabled = state;
        }

        if (state)
        {
            GetComponent<SpriteRenderer>().sprite = startImage;
            transform.position = start;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = endImage;
            transform.position = end;
        }
    }
}
