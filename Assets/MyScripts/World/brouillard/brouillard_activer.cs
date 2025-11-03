using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class brouillard_activer : MonoBehaviour
{
    GameObject player;
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        // Exemple de condition :
        if (other.CompareTag("player"))
        {
            RenderSettings.fog = true;
        }
    }
}
