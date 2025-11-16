using UnityEngine;
using UnityEngine.EventSystems;

public class script_bouton_anim_pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject menu_pause;
    private RectTransform rectTransform;
    private Vector3 tailleNormale;
    public float grossisement = 1.2f;
    public float duree_zoom = 0.2f;
    public float duree_entree = 1.5f;
    [SerializeField] public float position_finale_y; // position cible sur Y
    [SerializeField] float depart_y;       // position de départ hors écran
    bool anti_rep = true;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        tailleNormale = rectTransform.localScale;

        // Positionner hors écran
        Vector2 pos = rectTransform.anchoredPosition;
        pos.y = depart_y;
        rectTransform.anchoredPosition = pos;

        // Animation d’entrée depuis le haut

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Zoom au survol
        LeanTween.scale(rectTransform, tailleNormale * grossisement, duree_zoom)
                 .setEaseOutQuad();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Retour à la taille normale
        LeanTween.scale(rectTransform, tailleNormale, duree_zoom)
                 .setEaseOutQuad();
    }
    void Update()
    {
        /*if (menu_pause.GetComponent<script_pause>().ecran_pause_actif == true && anti_rep == true)
        {
            anti_rep = false;
            LeanTween.moveY(rectTransform, position_finale_y, duree_entree)
                 .setEaseOutBack(); // petit rebond sympa

        }
        if (menu_pause.GetComponent<script_pause>().ecran_pause_actif == false && anti_rep == false)
        {
            anti_rep = true;
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y = depart_y;
            rectTransform.anchoredPosition = pos;
        }*/

    }
}