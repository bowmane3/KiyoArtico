using UnityEngine;

public class GhostOrbit : GhostBase
{
    Transform arenaCenter;

    public float orbitSpeed = 50f;
    public float orbitDuration = 5f;
    public float rushSpeed = 2f;

    float timer;

    public void SetArenaCenter(Transform center)
    {
        arenaCenter = center;
    }

    void Update()
    {
        if (!player || !arenaCenter) return;

        timer += Time.deltaTime;

        if (timer < orbitDuration)
        {
            transform.RotateAround(arenaCenter.position, Vector3.up, orbitSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, rushSpeed * Time.deltaTime);
        }
    }
}