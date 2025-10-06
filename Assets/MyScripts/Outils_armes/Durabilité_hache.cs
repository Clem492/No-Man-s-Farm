using UnityEngine;

public class Durabilité_hache : MonoBehaviour
{
    int dura_hache;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dura_hache = 200;
    }

    // Update is called once per frame
    void Update()
    {
        destruction_hache();
    }
    void destruction_hache()
    {
        if (dura_hache <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void retirer_durabilite(int utilisation)
    {
        dura_hache -= utilisation;
    }
}
