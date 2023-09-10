using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    private Image progressbar;

    public static void LoadScene(string sceneame)
    {
        nextScene = sceneame;
        SceneManager.LoadScene("LoadingScene");
    }
    
    void Start()
    {
       StartCoroutine(LoadingControl());
    }
    IEnumerator LoadingControl()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while (!op.isDone)
        { 
            yield return null;

            if (op.progress < 0.2f)
            {
                progressbar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime * 0.25f;
                progressbar.fillAmount = Mathf.Lerp(0.2f, 1f, timer);
                if (progressbar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
