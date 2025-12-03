using UnityEngine;

public class explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explosion_prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lancement_explosion()
    {
        explosion_prefab.SetActive(true);
    }
    
}
