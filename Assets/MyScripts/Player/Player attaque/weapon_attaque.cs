using UnityEngine;

public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] GameObject camera;

    //variable pour connaitre savoir quelle arme le joueur a en main
    bool left_hand;
    bool right_hand;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject sickle;
    [SerializeField] GameObject pitchfork;

    //variable pour prendre les armes au sol
    Vector3 weapon_distance;

    //fonction pour savoir quelle arme le joueur a en main
    void What_weapon()
    {
        if (right_hand == false)
        {

        }
        if (left_hand == false)
        {

        }
    }


    //fonction pour prendre une arme par terre
    void Take_weapon()
    {
        
        if (Vector3.Distance(transform.position, axe.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la hache");
            if (Input.GetKeyDown(KeyCode.E))
            {
              
            }
        }
    }




    //fonction pour créer et voir un raycast
    void Weapon_collision_detected()
    {
        Debug.DrawRay(transform.position,camera.transform.forward * 2, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (Physics.Raycast(transform.position, camera.transform.forward, out hit, 2))
            {
                Destroy(hit.transform.gameObject);
            }
        }

    }

    private void Start()
    {
        left_hand = false;
        right_hand = false;
    }

    private void Update()
    {
        Weapon_collision_detected();
        Take_weapon();
        What_weapon();
    }
}
