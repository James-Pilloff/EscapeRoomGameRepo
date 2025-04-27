using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDetection : MonoBehaviour
{
    public string playerTag;
    public string mouseTag;
    public bool universal;
    public GameObject interactionManager;
    public GameObject escButton;
    public bool isInteracting;

    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();
    private bool inRange;
    private bool isClicked;
    private bool wasClicked;

    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(Physics2D.AllLayers);
        contactFilter.useLayerMask = true;
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (escButton.GetComponent<EscButton>().isPressed)
        {
            isInteracting = false;
        }

        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        inRange = universal;
        wasClicked = isClicked;
        isClicked = false;
        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == playerTag)
            {
                inRange = true;
            }
            if (results[index].tag == mouseTag)
            {
                isClicked = true;
            }
        }
        
        if (isClicked && !wasClicked && inRange && interactionManager.GetComponent<InteractionManagement>().canInteract)
        {
            isInteracting = true;
        }
    }
}
