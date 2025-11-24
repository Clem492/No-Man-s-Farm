using UnityEngine;

public class tp_arbre_sol : MonoBehaviour
{
    RaycastHit hit;
    Vector3 new_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deplacement();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(0, -100, 0), Color.red);
    }
    void deplacement()
    {
        Debug.DrawRay(transform.position, new Vector3(0, -100, 0) , Color.red);
        Physics.Raycast(transform.position, Vector3.down, out hit,100f);
        new_pos = hit.point;
        gameObject.transform.position = new_pos;
        Debug.Log(new_pos);
    }
}
