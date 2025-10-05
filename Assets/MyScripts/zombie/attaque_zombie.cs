using UnityEngine;

public class attaque_zombie : MonoBehaviour
{
    float degat_zombie = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(GameObject.FindWithTag("player").transform.position, gameObject.transform.position) < 1.2)
        {
            Destroy(GameObject.FindWithTag("player"));
        }
    }
}
