using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDetection : MonoBehaviour
{
    public string playerTag;
    public string mouseTag;
    public GameObject interactionManager;
    public GameObject escButton;
    public bool isInteracting;

    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();
    private bool inRange;
    private bool clicking;

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
        if (escButton.GetComponent<EscButton>().isPressed)
        {
            isInteracting = false;
        }

        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        inRange = false;
        clicking = false;
        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == playerTag)
            {
                inRange = true;
            }
            if (results[index].tag == mouseTag)
            {
                clicking = true;
            }
        }
        
        if (clicking && inRange && interactionManager.GetComponent<InteractionManagement>().canInteract)
        {
            isInteracting = true;
        }
    }
}
