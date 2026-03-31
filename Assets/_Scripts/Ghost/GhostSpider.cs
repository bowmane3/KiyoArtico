using UnityEngine;

public class GhostSpider : GhostBase
{
    [Header("Drop")]
    public float dropSpeed = 0.7f;
    public float dropHeight = 3f;

    [Header("Hanging Motion")]
    public float swayAmplitude = 0.15f;
    public float swaySpeed = 1.5f;

    public float bounceAmplitude = 0.03f;
    public float bounceSpeed = 2f;

    float targetHeight;
    bool reachedPosition = false;

    Vector3 basePosition;

    protected override void Start()
    {
        base.Start();

        targetHeight = transform.position.y - dropHeight;
    }

    void Update()
    {
        if (!reachedPosition)
        {
            DropDown();
        }
        else
        {
            HangMotion();
        }
    }

    void DropDown()
    {
        Vector3 pos = transform.position;

        pos.y -= dropSpeed * Time.deltaTime;

        if (pos.y <= targetHeight)
        {
            pos.y = targetHeight;
            reachedPosition = true;

            basePosition = pos;
        }

        transform.position = pos;
    }

    void HangMotion()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmplitude;
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceAmplitude;

        Vector3 pos = basePosition;

        pos.x += sway;
        pos.y += bounce;

        transform.position = pos;
    }
}