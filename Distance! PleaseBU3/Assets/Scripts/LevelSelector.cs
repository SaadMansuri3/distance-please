using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector:MonoBehaviour
{
    public FadeAnimationSC fadeAnim;
    public Button[] levelButtons;

    public AdMobSC admobsc;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void loadLevels(string LevelName)
    {
        fadeAnim.FadeTo(LevelName);
        //SceneManager.LoadScene(LevelName);
    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
