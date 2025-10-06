using Unity.Mathematics;
using UnityEngine;

public class weapon_animation : MonoBehaviour
{
    [SerializeField] GameObject axe;
    [SerializeField] Rigidbody rb;
    Vector3 position_initial;
    

    //fonction pour jouer l'animation de la hache
    void Axe_animation()
    {
        position_initial.x = math.clamp(position_initial.x, 0, 90);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
    }
    private void Start()
    {
     
    }
    private void Update()
    {
        Axe_animation();
    }


}
