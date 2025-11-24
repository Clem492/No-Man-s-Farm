using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ForceNavMesh : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FixPosition());
    }

    IEnumerator FixPosition()
    {
        yield return new WaitForEndOfFrame();

        // 1. Raycast au sol
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 2, Vector3.down, out hit, 200f))
        {
            Vector3 pos = hit.point + Vector3.up * 0.5f;

            // 2. Snap au NavMesh
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(pos, out navHit, 3f, NavMesh.AllAreas))
            {
                transform.position = navHit.position;
                yield break;
            }
        }

        Debug.LogError("❌ Impossible de placer le cerf sur le NavMesh : " + transform.position);
    }
}

