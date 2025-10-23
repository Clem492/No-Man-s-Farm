using UnityEngine;

public class dommage : MonoBehaviour
{
    [SerializeField] GameObject cam;
    void applay_dommage()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, cam.transform.forward * 4, Color.red);
        if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
        {
            if (hit.transform.GetComponent<pv_zombie>())
            {
                float pitchfork_dommage = 8;
                hit.transform.GetComponent<pv_zombie>().nb_pv_zombie -= pitchfork_dommage;
                Debug.Log("Zombie touché !");
            }
        }
    }
}
