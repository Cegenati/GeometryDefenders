using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn()); //How to call coroutine
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn ()
    {
        //When we fade in we want to go from black to seeing scene, alpha of 1 to 0
        float t = 1f;

        while (t>0f)
        {
            t -= Time.deltaTime; //IEnumerator gives you the power to select frames
            float a = curve.Evaluate(t);
            img.color = new Color (0,0f,0f,a);
            yield return 0; //Wait until the next fram
        }

    }

    IEnumerator FadeOut (string scene)
    {
        //When we fade in we want to go from black to seeing scene, alpha of 1 to 0
        float t = 0f;

        while (t<1f)
        {
            t += Time.deltaTime; //IEnumerator gives you the power to select frames
            float a = curve.Evaluate(t);
            img.color = new Color (0,0f,0f,a);
            yield return 0; //Wait until the next fram
        }

        SceneManager.LoadScene(scene);

    }
}
