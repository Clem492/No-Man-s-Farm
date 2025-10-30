using UnityEngine;

public class spawn_oeuf : MonoBehaviour
{
    [SerializeField] GameObject egg_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn_oeuf_vague()
    {
        Instantiate(egg_prefab, gameObject.transform.position, Quaternion.identity);
    }
}
