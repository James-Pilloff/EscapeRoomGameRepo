using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDetection : MonoBehaviour
{
    public string sceneName;
    public string playerTag;

    private bool wasClicked;
    private bool isClicked;
    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == playerTag)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
