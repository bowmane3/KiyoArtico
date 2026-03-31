using UnityEngine;

public class VRPlayerCollider : MonoBehaviour
{
    public Transform head;
    public CapsuleCollider capsule;

    void Update()
    {
        // Move collider to headset XZ
        Vector3 headPos = head.position;
        transform.position = new Vector3(headPos.x, transform.position.y, headPos.z);

        // Adjust collider height to match head
        float height = Mathf.Clamp(head.localPosition.y, 1f, 2f);
        capsule.height = height;
        capsule.center = new Vector3(0, height / 2f, 0);
    }
}