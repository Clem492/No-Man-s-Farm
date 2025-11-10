using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ScriptDemmarrage : MonoBehaviour
{
    private bool okForFade;
    [SerializeField] private RawImage imageNoire;
    [SerializeField] private GameObject image;
    [SerializeField] private float duration = 3f;

    void Start()
    {
        StartCoroutine(FadeFromBlack());
        image.SetActive(true);
    }

    IEnumerator FadeFromBlack()
    {
        Color color = imageNoire.color;
        float elapsed = 0f;

        color.a = 1f;
        imageNoire.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
            imageNoire.color = color;
            yield return null;
        }

        color.a = 0f;
        imageNoire.color = color;
    }
}