using UnityEngine;
using UnityEngine.AI;

public class mouvement_zombie: MonoBehaviour
{
    GameObject cible;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cible = GameObject.FindWithTag("player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(cible.transform.position);
    }
}
