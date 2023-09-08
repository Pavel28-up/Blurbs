using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadLobby : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image loadBar;
    public TMP_Text barTxt;
    public int sceneId;

    private float progress;

    private void Start()
    {
        StartCoroutine(LoadSceneCorId());
    }

    private void Update()
    {
        barTxt.text = " Loading: " + Mathf.FloorToInt(progress * 100) + "%";
    }


    IEnumerator LoadSceneCorId()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneId);
        while (!asyncOperation.isDone)
        {
            progress = asyncOperation.progress / 0.9f;
            loadBar.fillAmount = progress;
            barTxt.text = " Loading: " + Mathf.FloorToInt(progress * 100) + "%";
            yield return 0;
        }
    }
}