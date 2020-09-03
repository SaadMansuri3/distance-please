using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAnimationSC : MonoBehaviour
{
    public Animator fadeTransition;
    public float transitionTime = 1f;

    public void FadeTo(string scene)
    { 
        StartCoroutine(fadeAnim(scene));
    }

    IEnumerator fadeAnim(string scene)
    {
        fadeTransition.SetTrigger("Start");
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(scene);
    }
    
}
