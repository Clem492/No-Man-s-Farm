using System.Collections;
using UnityEngine;

public class ScriptAnimWin : MonoBehaviour
{
    [SerializeField] float duree_entree,duree_sortie;
    [SerializeField] public float position_finale_y; // position cible sur Y
    [SerializeField] float depart_y,fin_y;
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Vector2 pos = rectTransform.anchoredPosition;
        pos.y = depart_y;
        rectTransform.anchoredPosition = pos;
        StartCoroutine(mouvement_text());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator mouvement_text()
    {
        LeanTween.moveY(rectTransform, position_finale_y, duree_entree)
                 .setEaseOutBack(); // petit rebond sympa
        yield return new WaitForSeconds(15);
        LeanTween.moveY(rectTransform, fin_y, duree_entree)
                 .setEaseOutBack();
    }
}
