using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnPress : MonoBehaviour
{
    public string sceneName;
    public string mouseTag;
    public GameObject mouse;

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
            SceneManager.LoadScene(sceneName);
        }

        wasClicked = mouse.GetComponent<Collider2D>().enabled;
    }
}
