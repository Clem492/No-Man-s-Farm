using UnityEngine;

public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] GameObject cam;

    

    //fonction pour créer et voir un raycast
    void Weapon_collision_detected()
    {
        Debug.DrawRay(transform.position,cam.transform.forward * 2, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 2))
            {
                Destroy(hit.transform.gameObject);
            }
        }

    }

   
    private void Update()
    {
        Weapon_collision_detected();
     
    }
}
