using UnityEngine;

public class Durabilité_fourche : MonoBehaviour
{
    int dura_fourche;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dura_fourche = 150;
    }

    // Update is called once per frame
    void Update()
    {
        destruction_fourche();
    }
    void destruction_fourche()
    {
        if (dura_fourche <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void retirer_durabilite(int utilisation)
    {
        dura_fourche -= utilisation;
    }
}
