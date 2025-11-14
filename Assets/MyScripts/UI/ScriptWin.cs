using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWin : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text_win_defaite , credits , nom;
    [SerializeField] GameObject panel_credit, panel_histoire;    // position de départ hors écran
    string scene_demarrage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel_histoire.SetActive(true);
        scene_demarrage = "SceneMenu";
        text_win_defaite.enabled = false;
        credits.enabled = false;
        nom.enabled = false;
        panel_credit.SetActive(false);
        
        StartCoroutine(fin_credits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator fin_credits()
    {
        
        yield return new WaitForSeconds(20);
        panel_histoire.SetActive(false);
        panel_credit .SetActive(true);
        text_win_defaite.enabled = true;
        yield return new WaitForSeconds(1);
        credits.enabled = true;
        yield return new WaitForSeconds(1);
        nom.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene_demarrage);
    }
}
