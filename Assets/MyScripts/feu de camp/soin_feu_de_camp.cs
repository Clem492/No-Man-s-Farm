using UnityEngine;
using System.Collections;
public class soin_feu_de_camp : MonoBehaviour
{
    [SerializeField] ParticleSystem croix_vert;
    GameObject player;
    bool anti_spam_soin;
    float pv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        croix_vert.Stop();
    }

    void Start()
    {
        
        anti_spam_soin = true;
        player = GameObject.FindWithTag("player");
        pv = player.GetComponent<pv_player>().nb_pv_player;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("le joueur na pas été trouver");
        }
        pv = player.GetComponent<pv_player>().nb_pv_player;
        soin_player_proche();
    }
    void soin_player_proche()
    {
        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 5 && anti_spam_soin == true && pv <10)
        {
            anti_spam_soin = false;
            StartCoroutine(soin());
        }
    }
    IEnumerator soin()
    {
       
           
        player.GetComponent<pv_player>().nb_pv_player += 1;
        croix_vert.Play();
        yield return new WaitForSeconds(1);
        croix_vert.Stop();
        yield return new WaitForSeconds(4);
        anti_spam_soin = true;
    }
}
