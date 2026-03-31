using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Teleport : MonoBehaviour
{
    public TeleportationProvider TeleportationProvider;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TeleportationProvider = FindAnyObjectByType<TeleportationProvider>();
    }

    public void Tp()
    {
        TeleportRequest teleportRequest = new();
        teleportRequest.destinationPosition = target.position;
        teleportRequest.destinationRotation = target.rotation;
        teleportRequest.matchOrientation = MatchOrientation.TargetUpAndForward;
        TeleportationProvider.QueueTeleportRequest(teleportRequest);

    }

    public void OnTriggerEnter(Collider other)
    {
        Tp();
    }
}
