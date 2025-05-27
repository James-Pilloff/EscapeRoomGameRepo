using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBookManager : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    public int bookLength;
    public int currentPage = 0;
    public GameObject currentSprite;
    public GameObject hundreds1;
    public GameObject tens1;
    public GameObject ones1;
    public GameObject hundreds2;
    public GameObject tens2;
    public GameObject ones2;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = pages[currentPage];
    }

    // Update is called once per frame
    void Update()
    {
        currentSprite.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        hundreds1.GetComponent<NumberDisplay>().currentDigit = (int) Mathf.Floor((currentPage*2+1)/100);
        tens1.GetComponent<NumberDisplay>().currentDigit = (int) Mathf.Floor((currentPage*2+1)/10)%10;
        ones1.GetComponent<NumberDisplay>().currentDigit = (currentPage*2+1)%10;
        hundreds2.GetComponent<NumberDisplay>().currentDigit = (int) Mathf.Floor((currentPage*2+2)/100);
        tens2.GetComponent<NumberDisplay>().currentDigit = (int) Mathf.Floor((currentPage*2+2)/10)%10;
        ones2.GetComponent<NumberDisplay>().currentDigit = (currentPage*2+2)%10;

        hundreds1.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        tens1.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        ones1.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        hundreds2.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        tens2.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
        ones2.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
    }

    public void NextPage()
    {
        currentSprite.GetComponent<SpriteRenderer>().enabled = false;
        currentPage ++;
        currentSprite = pages[currentPage];
        currentSprite.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void PreviousPage()
    {
        currentSprite.GetComponent<SpriteRenderer>().enabled = false;
        currentPage --;
        currentSprite = pages[currentPage];
        currentSprite.GetComponent<SpriteRenderer>().enabled = true;
    }
}
