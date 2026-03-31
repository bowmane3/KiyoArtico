using UnityEngine;

public class GhostSnake : GhostBase
{
    public float moveSpeed = 1f;
    public float wiggleSpeed = 5f;
    public float wiggleAmount = 0.4f;

    void Update()
    {
        if (!player) return;

        Vector3 dir = (player.position - transform.position).normalized;

        Vector3 move = dir * moveSpeed * Time.deltaTime;

        Vector3 wiggle = transform.right * Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount * Time.deltaTime;

        transform.position += move + wiggle;

        transform.LookAt(player);
    }
}