using UnityEngine;

public class piege_degats : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        degat();
    }
    void degat()
    {
        GameObject[] zombie_tab = GameObject.FindGameObjectsWithTag("zombie");


        foreach (GameObject zombie in zombie_tab)
        {
            if (Vector3.Distance(transform.position,zombie.transform.position) <= 2f)
            {
               
                Destroy(zombie);
                Destroy(gameObject);
            }

        }
        
    }
}
