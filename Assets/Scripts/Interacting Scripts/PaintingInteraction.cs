using UnityEngine;

public class PaintingInteraction : MonoBehaviour, IInteractable
{
    public GameObject paintingCanvas;

    public void Interact()
    {
        paintingCanvas.SetActive(true);
    }

    void Start()
    {
        paintingCanvas.SetActive(false);
    }

    void Update()
    {
        if (paintingCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            paintingCanvas.SetActive(false);
        }
    }
}