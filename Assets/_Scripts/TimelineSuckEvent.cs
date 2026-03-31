using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class TimelineSuckEvent : MonoBehaviour
{
    public Collider targetCollider;
    public Transform playerRig;
    public Transform suckPoint;

    public Light mainLight;

    public float brightIntensity = 0.75f;
    public float darkIntensity = 0f;

    public float lightFadeTime = 0.3f;
    public float suckDuration = 1.5f;

    PlayableDirector director;
    bool started = false;

    void Start()
    {
        director = GetComponent<PlayableDirector>();

        if (mainLight != null)
            mainLight.intensity = darkIntensity;
    }

    void Update()
    {
        if (started)
            return;

        // REEMPLAZAR ESTA WEA CON INPUT DE VR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTimeline();
        }
    }

    void StartTimeline()
    {
        started = true;

        StartCoroutine(FadeLight(darkIntensity, brightIntensity));

        if (director != null)
            director.Play();
    }

    public void StartSuckSequence()
    {
        if (targetCollider != null)
            targetCollider.enabled = false;

        StartCoroutine(SuckPlayer());
    }

    IEnumerator SuckPlayer()
    {
        Vector3 start = playerRig.position;
        Vector3 end = suckPoint.position;

        float t = 0f;

        while (t < suckDuration)
        {
            t += Time.deltaTime;
            float p = t / suckDuration;

            playerRig.position = Vector3.Lerp(start, end, p);

            yield return null;
        }

        StartCoroutine(FadeLight(brightIntensity, darkIntensity));
    }

    IEnumerator FadeLight(float from, float to)
    {
        float t = 0f;

        while (t < lightFadeTime)
        {
            t += Time.deltaTime;
            float p = Mathf.SmoothStep(0, 1, t / lightFadeTime);

            mainLight.intensity = Mathf.Lerp(from, to, p);

            yield return null;
        }

        mainLight.intensity = to;
    }
}