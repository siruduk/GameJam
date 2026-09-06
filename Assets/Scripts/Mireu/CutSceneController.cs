using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
    public GameObject unAc;
    public GameObject ac;

    public Image fadeImage;
    public float fadeDuration = 1f;
    public GameObject cutSceneObject;
    public float cutSceneDuration = 3.5f;

    [SerializeField]
    GameObject[] player; 
    

    bool isNaturalDead;

    private void Start()
    {
        // 시작 시 이미지가 완전히 투명하도록 설정
        if (fadeImage != null)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        }
        else
        {
            Debug.LogError("Fade Image is not assigned!");
        }
    }

    public void PlayCutScene()
    {
        StartCoroutine(CutSceneSequence());
    }

    private IEnumerator CutSceneSequence()
    {
        if(ac == unAc)
            unAc.GetComponent<PlayerMovement>().enabled = false;
        else if (ac == null)
        {
            isNaturalDead = true;
            unAc.GetComponent<PlayerMovement>().enabled = false;
            unAc.GetComponent<MeshRenderer>().enabled = false;
        }

        if (!isNaturalDead)
        {
            ac.SetActive(true);
            ac.transform.GetChild(1).gameObject.SetActive(false);
            unAc.GetComponent<PlayerMovement>().enabled = false;
            unAc.SetActive(false);
            ac.GetComponent<PlayerMovement>().enabled = false;
        }
        


        yield return StartCoroutine(FadeCoroutine(0f, 1f));

        if (cutSceneObject != null)
        {
            cutSceneObject.SetActive(true);
        }

        

        yield return StartCoroutine(FadeCoroutine(1f, 0f));

        yield return new WaitForSeconds(cutSceneDuration);

        yield return StartCoroutine(FadeCoroutine(0f, 1f));
        if (cutSceneObject != null)
        {
            cutSceneObject.SetActive(false);
        }

        if (ac == unAc)
            Application.Quit();

        yield return StartCoroutine(FadeCoroutine(1f, 0f));

        if (isNaturalDead)
        {
            if (SceneManager.GetActiveScene().name.Equals("A"))
                SceneManager.LoadScene("B");
            else
                SceneManager.LoadScene("A");

        }
        else
        {
            ac.GetComponent<PlayerMovement>().enabled = true;
            ac.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private IEnumerator FadeCoroutine(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, endAlpha);
    }


}
