using System.Collections;
using UnityEngine;

public class DitherFadeGroup : MonoBehaviour
{
    public float fadeDuration = 2f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip fadeSound;

    private Renderer[] renderers;
    private bool hasTriggered = false; // prevents re-trigger

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        SetAlpha(0f);
    }

    void Update()
    {
        if (!hasTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            hasTriggered = true;

            // Play sound once
            if (audioSource != null && fadeSound != null)
            {
                audioSource.PlayOneShot(fadeSound);
            }

            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            float alpha = Mathf.SmoothStep(0f, 1f, time / fadeDuration);
            SetAlpha(alpha);

            time += Time.deltaTime;
            yield return null;
        }

        SetAlpha(1f);
    }

    void SetAlpha(float alpha)
    {
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                if (mat.HasProperty("_BaseColor"))
                {
                    Color c = mat.GetColor("_BaseColor");
                    c.a = alpha;
                    mat.SetColor("_BaseColor", c);
                }
            }
        }
    }
}