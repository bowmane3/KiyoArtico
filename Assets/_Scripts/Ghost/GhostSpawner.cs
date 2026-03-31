using UnityEngine;
using System.Collections;

public class GhostSpawner : MonoBehaviour
{
    [Header("Ghost Prefabs")]
    public GameObject spiderGhost;
    public GameObject snakeGhost;
    public GameObject orbitGhost;

    [Header("Spawn Points")]
    public Transform[] spiderSpawnPoints;
    public Transform[] snakeSpawnPoints;
    public Transform[] orbitSpawnPoints;

    [Header("First Spawn Delays")]
    public float firstOrbitSpawnDelay = 1f;
    public float firstSpiderSpawnDelay = 5f;
    public float firstSnakeSpawnDelay = 8f;

    [Header("Spawn Intervals")]
    public float orbitSpawnInterval = 6f;
    public float spiderSpawnInterval = 7f;
    public float snakeSpawnInterval = 5f;

    public Transform arenaCenter;

    void Start()
    {
        StartCoroutine(OrbitSpawnRoutine());
        StartCoroutine(SpiderSpawnRoutine());
        StartCoroutine(SnakeSpawnRoutine());
    }

    IEnumerator OrbitSpawnRoutine()
    {
        yield return new WaitForSeconds(firstOrbitSpawnDelay);

        while (true)
        {
            SpawnOrbitGhost();
            yield return new WaitForSeconds(orbitSpawnInterval);
        }
    }

    IEnumerator SpiderSpawnRoutine()
    {
        yield return new WaitForSeconds(firstSpiderSpawnDelay);

        while (true)
        {
            SpawnSpider();
            yield return new WaitForSeconds(spiderSpawnInterval);
        }
    }

    IEnumerator SnakeSpawnRoutine()
    {
        yield return new WaitForSeconds(firstSnakeSpawnDelay);

        while (true)
        {
            SpawnSnake();
            yield return new WaitForSeconds(snakeSpawnInterval);
        }
    }

    void SpawnOrbitGhost()
    {
        if (orbitSpawnPoints.Length == 0) return;

        Transform spawn = orbitSpawnPoints[Random.Range(0, orbitSpawnPoints.Length)];

        GameObject ghost = Instantiate(orbitGhost, spawn.position, spawn.rotation);

        GhostOrbit orbit = ghost.GetComponent<GhostOrbit>();

        if (orbit != null)
            orbit.SetArenaCenter(arenaCenter);
    }

    void SpawnSpider()
    {
        if (spiderSpawnPoints.Length == 0) return;

        Transform spawn = spiderSpawnPoints[Random.Range(0, spiderSpawnPoints.Length)];

        Instantiate(spiderGhost, spawn.position, spawn.rotation);
    }

    void SpawnSnake()
    {
        if (snakeSpawnPoints.Length == 0) return;

        Transform spawn = snakeSpawnPoints[Random.Range(0, snakeSpawnPoints.Length)];

        Instantiate(snakeGhost, spawn.position, spawn.rotation);
    }
}