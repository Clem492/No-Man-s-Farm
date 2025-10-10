using System.Net;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class weaponinstantiate : MonoBehaviour

{
   public GameObject hand_right;


    //variable pour connaitre savoir quelle arme le joueur a en main
    public bool left_hand;
   public bool right_hand;
    public bool weapon_hand;
    bool firs_hand;//utiliser pour mettre les armes dans la main droite en premier 
    bool double_hand;
   public int weapon_diff; //variable utile pour savoir si il y a un object diff�rent dans chaque main 1 pour la hache et 2 pour la houe et d'autre chiffre pour les prochaines armes
    [SerializeField] Transform left_hand_position;
    [SerializeField] Transform right_hand_position;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject sickle;
    [SerializeField] GameObject pitchfork_prefab;
    [SerializeField] GameObject pitchfork;

    Animator animator;

    //fonction pour savoir quelle arme le joueur a en main
    void What_hand()
    {

        if (right_hand == false)
        {
            firs_hand = true;
            Take_weapon_right();
        }
        if (left_hand == false && right_hand == true && firs_hand == false && double_hand == false)
        {
            Take_weapon_left();
        }
        firs_hand = false;
    }




    //fonction pour prendre une arme par terre
    void Take_weapon_right()
    {
        
        
        if (Vector3.Distance(transform.position, axe.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la hache");
            if (Input.GetKeyDown(KeyCode.E))
            {
                hand_right = Instantiate(axe);
                hand_right.transform.SetParent(right_hand_position, false);//permet de mettre la hache en enfant
                hand_right.transform.localPosition = new Vector3(0, 0.6f, 0);
                hand_right.transform.localRotation = Quaternion.Euler(90, 90, 0);
                right_hand = true;
                weapon_diff = 1;

            }
        }
        if (Vector3.Distance(transform.position, sickle.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la houe");
            if (Input.GetKeyDown(KeyCode.E))
            {
                hand_right = Instantiate(sickle);
                hand_right.transform.SetParent(right_hand_position, false);//permet de mettre la hache en enfant
                hand_right.transform.localPosition = new Vector3(0, 0.6f, 0);
                hand_right.transform.localRotation = Quaternion.Euler(90, 0, 90);
                right_hand = true;
                weapon_diff = 2;

            }
        }
        if (Vector3.Distance(transform.position, pitchfork.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la fourche");

            if (Input.GetKeyDown(KeyCode.E))
            {

                // Instanciation de la fourche
                 hand_right = Instantiate(pitchfork_prefab);

                // Parent � la main droite
                hand_right.transform.SetParent(right_hand_position, false);

                // Position et rotation locales
                hand_right.transform.localPosition = new Vector3(0, 0, -0.5f);
                Debug.Log("bien instantier");
                hand_right.transform.localRotation = Quaternion.Euler(0, -90, 0);

                // Mise � jour des �tats
                right_hand = true;
                double_hand = true;
                weapon_diff = 3;
                weapon_hand = true;
            }
        }
    }

    //fonction pour instantiate une arme
   

    void Take_weapon_left()
    {
        GameObject hand_right;
        if (Vector3.Distance(transform.position, axe.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la hache");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (weapon_diff == 1)
                {
                    hand_right = Instantiate(axe);
                    hand_right.transform.SetParent(left_hand_position, false);//permet de mettre la hache en enfant
                    hand_right.transform.localPosition = new Vector3(0, 0.6f, 0);
                    hand_right.transform.localRotation = Quaternion.Euler(90, 90, 0);
                    left_hand = true;
                }

            }

        }
        if (Vector3.Distance(transform.position, sickle.transform.position) < 2)
        {
            Debug.Log("tu peux prendre la houe");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (weapon_diff == 2)
                {
                    hand_right = Instantiate(sickle);
                    hand_right.transform.SetParent(left_hand_position, false);//permet de mettre la hache en enfant
                    hand_right.transform.localPosition = new Vector3(0, 0.6f, 0);
                    hand_right.transform.localRotation = Quaternion.Euler(90, 0, 90);
                    left_hand = true;
                }


            }
    }   }

    void nothing_in_hand()
    {
        if (right_hand == false)
        {
            weapon_diff = 0;
        }
    }
    private void Start()
    {
        weapon_hand = false;
        weapon_diff = 0;
        left_hand = false;
        right_hand = false;
        firs_hand = false;
        double_hand = false;
        animator = pitchfork.GetComponent<Animator>();
    }

    private void Update()
    {
        nothing_in_hand();
        What_hand();
    }
}


