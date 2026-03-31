using UnityEngine;

public class VRGazeDamage : MonoBehaviour
{
    public float damagePerSecond = 1f;
    public float maxDistance = 15f;
    public float gazeAngle = 8f;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, maxDistance);

        foreach (Collider col in hits)
        {
            GhostBase ghost = col.GetComponent<GhostBase>();
            if (ghost == null) continue;

            Vector3 dirToGhost = (ghost.transform.position - transform.position).normalized;

            float angle = Vector3.Angle(transform.forward, dirToGhost);
            if (angle > gazeAngle) continue;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dirToGhost, out hit, maxDistance))
            {
                GhostBase hitGhost = hit.collider.GetComponent<GhostBase>();

                if (hitGhost == ghost)
                {
                    ghost.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Vector3 origin = transform.position;
        Vector3 forward = transform.forward;

        Gizmos.DrawWireSphere(origin, maxDistance);

    
        float coneRadius = Mathf.Tan(gazeAngle * Mathf.Deg2Rad) * maxDistance;

        Vector3 coneCenter = origin + forward * maxDistance;

        int segments = 32;
        Vector3 prevPoint = Vector3.zero;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (i / (float)segments) * Mathf.PI * 2;

            Vector3 circlePoint =
            coneCenter
            + transform.right * Mathf.Cos(angle) * coneRadius
            + transform.up * Mathf.Sin(angle) * coneRadius;

            if (i > 0)
            Gizmos.DrawLine(prevPoint, circlePoint);

            prevPoint = circlePoint;
        }

        Gizmos.DrawLine(origin, coneCenter + transform.right * coneRadius);
        Gizmos.DrawLine(origin, coneCenter - transform.right * coneRadius);
        Gizmos.DrawLine(origin, coneCenter + transform.up * coneRadius);
        Gizmos.DrawLine(origin, coneCenter - transform.up * coneRadius);
    }
}