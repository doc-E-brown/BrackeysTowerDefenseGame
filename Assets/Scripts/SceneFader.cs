using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image image;
    public AnimationCurve curve;


    IEnumerator FadeIn()
    {
        float t = 1f;
        
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float alpha = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
    }
    
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        
        while (t < 0f)
        {
            t += Time.deltaTime;
            float alpha = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
