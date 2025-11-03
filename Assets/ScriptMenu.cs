using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScriptMenu : MonoBehaviour
{
    private bool okForFade;
    [SerializeField] private RawImage imageNoire;
    [SerializeField] private float duration = 5f;
    [SerializeField] private string sceneToLoad = "Scene1";

    void Start()
    {
        okForFade = true;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (okForFade && Input.GetKeyDown(KeyCode.Space))
        {
            okForFade = false;
            StartCoroutine(FadeOutAndChangeScene());
        }
    }

    IEnumerator FadeOutAndChangeScene()
    {
        Color color = imageNoire.color;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsed / duration);
            imageNoire.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
