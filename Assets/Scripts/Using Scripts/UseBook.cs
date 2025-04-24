using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UseBook : MonoBehaviour, IUsable
{
    public GameObject bookCanvas;
    public string bookText;  // The full text of the book
    public TMP_Text leftPageText;  // The TMP text component for the left page
    public TMP_Text rightPageText;  // The TMP text component for the right page
    public TMP_Text pageLabel;

    private int currentLeftPageNumber = 0;  // Current left page number
    private int totalPages;  // Total number of pages
    private string[] pageContents;  // Array to store content for each page

    public void Use()
    {
        gameObject.SetActive(true);
        bookCanvas.SetActive(true);
        UpdatePageContent();
    }

    public void Close(){
        gameObject.SetActive(false);
        bookCanvas.SetActive(false);
    }

    void Start()
    {
        bookCanvas.SetActive(false);
        SplitBookTextIntoPages();  // Split book text into pages at start
    }

    void Update()
    {
        if (bookCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    // Split the book text into pages
        private void SplitBookTextIntoPages()
    {
        // Split the book text by the "|||" delimiter
        pageContents = bookText.Split(new string[] { "|||" }, System.StringSplitOptions.None);

        totalPages = pageContents.Length;  // Set total pages based on the number of splits
    }

    // Turn the page to the right (next page)
    public void TurnPageRight()
    {
        // Check if the current left page number is within bounds
        if (currentLeftPageNumber + 2 < totalPages)
        {
            currentLeftPageNumber += 2;  // Move to the next set of pages
            UpdatePageContent();  // Update the content on the pages
        }
    }

    // Turn the page to the left (previous page)
    public void TurnPageLeft()
    {
        if (currentLeftPageNumber > 0)
        {
            currentLeftPageNumber -= 2;  // Move to the previous set of pages
            UpdatePageContent();  // Update the content on the pages
        }
    }

    // Update the content of the left and right pages
    private void UpdatePageContent()
    {
        // Ensure the left and right pages are within the total page range
        if (currentLeftPageNumber < totalPages)
        {
            leftPageText.text = pageContents[currentLeftPageNumber];
        }
        else
        {
            leftPageText.text = "";
        }

        if (currentLeftPageNumber + 1 < totalPages)
        {
            rightPageText.text = pageContents[currentLeftPageNumber + 1];
        }
        else
        {
            rightPageText.text = "";
        }

        pageLabel.text = "Page " + (currentLeftPageNumber + 1) + ", " + (currentLeftPageNumber + 2) + " of " + totalPages;
    }
}
