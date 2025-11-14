using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptDefaite : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text_win_defaite, credits, nom;
    string scene_demarrage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene_demarrage = "SceneMenu";
        text_win_defaite.enabled = false;
        credits.enabled = false;
        nom.enabled = false;
        StartCoroutine(loose());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator loose()
    {
        text_win_defaite.enabled = true;
        yield return new WaitForSeconds(1);
        credits.enabled = true;
        yield return new WaitForSeconds(1);
        nom.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene_demarrage);
    }
}
