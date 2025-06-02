using UnityEngine;

public class WinScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;     // Assign this in the Inspector
    public float fadeDuration = 2f;     // Duration for full fade in (seconds)

    private float fadeTimer = 0f;
    private bool isFadingIn = true;

    void Start()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not assigned!");
            return;
        }

        canvasGroup.alpha = 0f; // Start fully transparent
    }

    void Update()
    {
        if (isFadingIn && canvasGroup.alpha < 1f)
        {
            fadeTimer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
        }
    }
}
