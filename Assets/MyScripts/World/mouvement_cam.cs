using System.Collections;
using UnityEngine;

public class mouvement_cam : MonoBehaviour
{
    [SerializeField] float pos_cam_depart_z,pos_cam_arriver_z;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(mouv_cam());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator mouv_cam()
    {
        while (true)
        {
            while (transform.position.z < pos_cam_arriver_z)
            {
                transform.position = new Vector3(transform.position.x + 0.075f, transform.position.y - 0.025f, transform.position.z + 0.150f);
                yield return new WaitForSeconds(0.025f);
            }
            while (transform.position.z > pos_cam_depart_z)
            {
                transform.position = new Vector3(transform.position.x - 0.075f, transform.position.y + 0.025f, transform.position.z - 0.150f);
                yield return new WaitForSeconds(0.025f);
            }
        }
        
    }
}
