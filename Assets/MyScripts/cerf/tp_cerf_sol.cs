using UnityEngine;

public class tp_cerf_sol : MonoBehaviour
{
    RaycastHit hit;
    Vector3 new_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        deplacement();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void deplacement()
    {
        Debug.DrawRay(transform.position, new Vector3(0, -100, 0), Color.red);
        Physics.Raycast(transform.position, Vector3.down, out hit, 100f);
        new_pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        gameObject.transform.position = new_pos;

    }
}
