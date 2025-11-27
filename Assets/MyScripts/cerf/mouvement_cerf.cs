using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class mouvement_cerf : MonoBehaviour
{
    [SerializeField] float temps_entre_deplacements = 5f;
    GameObject[] cerf_pos_tab;
    NavMeshAgent agent;

    IEnumerator Start()
    {
        // attendre que tp_cerf_sol ait fini son travail
        yield return null;

        agent = GetComponent<NavMeshAgent>();

        // Vérification IMPORTANTE
        if (!agent.isOnNavMesh)
        {
           
            yield break;
        }

        cerf_pos_tab = GameObject.FindGameObjectsWithTag("cible_cerf");

        StartCoroutine(ChangeDestination());
    }

    IEnumerator ChangeDestination()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int pos = Random.Range(0, cerf_pos_tab.Length);
            Vector3 cible = cerf_pos_tab[pos].transform.position;

            agent.SetDestination(cible);
            yield return new WaitForSeconds(temps_entre_deplacements);

            
        }
    }
}

