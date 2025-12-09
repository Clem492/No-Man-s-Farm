using UnityEngine;

public class dura_arme : MonoBehaviour
{
    [SerializeField] public int dura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destruction();
        Debug.Log(dura);
    }
    public void retirer_dura()
    {
        dura -= 1;
    }
    void destruction()
    {
        if (dura <= 0)
        {
            Destroy(gameObject);
        }
    }
}
