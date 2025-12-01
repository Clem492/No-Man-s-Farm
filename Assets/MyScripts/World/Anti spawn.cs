using System.Collections;
using UnityEngine;

public class Antispawn : MonoBehaviour
{
    [SerializeField] float distance;

    void Start()
    {
        StartCoroutine(destruction());
    }

    IEnumerator destruction()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject[] tab_truc_a_detruire = GameObject.FindGameObjectsWithTag("detruire");

            foreach (GameObject truc_a_detruire in tab_truc_a_detruire)
            {
                if (Vector3.Distance(truc_a_detruire.transform.position, transform.position) < distance)
                {
                    Destroy(truc_a_detruire);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}