using UnityEngine;
using UnityEngine.UI;

public class TableInteraction : MonoBehaviour, IInteractable
{
    public GameObject tableCanvas;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    public Image image1;
    public Image image2;
    public Image image3;

    public Image highlight1;
    public Image highlight2;
    public Image highlight3;

    void Start()
    {
        tableCanvas.SetActive(false);

        SetupItem(item1, image1, highlight1);
        SetupItem(item2, image2, highlight2);
        SetupItem(item3, image3, highlight3);

        highlight1.gameObject.SetActive(false);
        highlight2.gameObject.SetActive(false);
        highlight3.gameObject.SetActive(false);
    }

    void Update()
{
    if (tableCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
    {
        tableCanvas.SetActive(false);
    }

    if (!tableCanvas.activeSelf)
        return;

    Vector2 mousePos = Input.mousePosition;

    // Show highlight on hover
    bool hovering1 = image1 != null && image1.gameObject.activeSelf && IsHovered(image1, mousePos);
    bool hovering2 = image2 != null && image2.gameObject.activeSelf && IsHovered(image2, mousePos);
    bool hovering3 = image3 != null && image3.gameObject.activeSelf && IsHovered(image3, mousePos);

    if (highlight1 != null) highlight1.gameObject.SetActive(hovering1);
    if (highlight2 != null) highlight2.gameObject.SetActive(hovering2);
    if (highlight3 != null) highlight3.gameObject.SetActive(hovering3);

    if (Input.GetMouseButtonDown(0))
    {
        if (hovering1) ActivateItem(item1, image1, highlight1);
        else if (hovering2) ActivateItem(item2, image2, highlight2);
        else if (hovering3) ActivateItem(item3, image3, highlight3);
    }
}


    public void Interact()
    {
        tableCanvas.SetActive(true);
    }

    void SetupItem(GameObject item, Image image, Image highlight)
    {
        if (item != null)
        {
            item.SetActive(false);

            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                if (image != null)
                {
                    image.sprite = sr.sprite;
                    image.color = sr.color;
                    image.gameObject.SetActive(true);
                }

                if (highlight != null)
                {
                    highlight.sprite = sr.sprite;
                    highlight.color = new Color(1f, 1f, 1f, 1f); // semi-transparent white
                    highlight.rectTransform.localScale = Vector3.one * 1.1f; // scale up
                    highlight.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning($"SpriteRenderer not found on {item.name}");
                if (image != null) image.gameObject.SetActive(false);
                if (highlight != null) highlight.gameObject.SetActive(false);
            }
        }
        else
        {
            if (image != null) image.gameObject.SetActive(false);
            if (highlight != null) highlight.gameObject.SetActive(false);
        }
    }

    void ActivateItem(GameObject item, Image image, Image highlight)
    {
        if (item != null)
            item.SetActive(true);

        if (image != null)
            image.gameObject.SetActive(false);

        if (highlight != null)
            highlight.gameObject.SetActive(false);
    }

    bool IsClicked(Image image, Vector2 mousePosition)
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, null);
    }

    bool IsHovered(Image image, Vector2 mousePosition)
{
    RectTransform rectTransform = image.GetComponent<RectTransform>();
    return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, null);
}

}
