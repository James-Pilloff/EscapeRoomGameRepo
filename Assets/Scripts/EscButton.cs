using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscButton : MonoBehaviour
{
    public string mouseTag;
    public GameObject interactionManager;
    public bool isPressed;

    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();
    
    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(Physics2D.AllLayers);
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        isPressed = false;

        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == mouseTag)
            {
                isPressed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPressed = true;
        }

        GetComponent<SpriteRenderer>().enabled = !interactionManager.GetComponent<InteractionManagement>().canInteract;
    }
}
