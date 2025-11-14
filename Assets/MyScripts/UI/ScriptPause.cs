using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_pause : MonoBehaviour
{

    [SerializeField] Button bouton_continuer, boutton_quitter;
    [SerializeField] GameObject ecran_pause;
    [SerializeField] Canvas canvas;
    public bool ecran_pause_actif;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ecran_pause_actif = false;
        ecran_pause.SetActive(false);
        bloquer_souris();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            ecran_pause_actif = !ecran_pause_actif;
            if (ecran_pause_actif)
            {
                ecran_pause.SetActive(true);
                canvas.enabled = false;
            }
            else
            {
                ecran_pause.SetActive(false);
                canvas.enabled = true;
            }
        }
       
        bloquer_souris();
    }
    public void Continuer()
    {
        ecran_pause.SetActive(false);
        ecran_pause_actif = false;
        canvas.enabled = true;
    }
    public void Quitter()
    {
        //Quitte le jeu
        Application.Quit();

    }
    void bloquer_souris()
    {
        if (ecran_pause_actif)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
       
    }
}