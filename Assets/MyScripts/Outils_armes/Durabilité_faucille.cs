using UnityEngine;

public class Durabilité_faucille : MonoBehaviour
{
    int dura_faucille;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dura_faucille = 100;
    }

    // Update is called once per frame
    void Update()
    {
        destruction_faucille();
    }
    void destruction_faucille()
    {
        if (dura_faucille <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void retirer_durabilite(int utilisation)
    {
        dura_faucille -= utilisation;
    }
}
