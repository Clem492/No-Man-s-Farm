using UnityEngine;

public class spawn_oeuf : MonoBehaviour
{
    [SerializeField] GameObject egg_prefab;
     GameObject chicken;
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
        chicken = GameObject.FindWithTag("poule");
        
        Instantiate(egg_prefab, new Vector3(chicken.transform.position.x,2, chicken.transform.position.z), Quaternion.identity);
    }
}
