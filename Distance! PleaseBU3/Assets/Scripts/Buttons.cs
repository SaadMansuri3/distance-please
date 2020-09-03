using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private string LevelSelector = "Level Selector";
    private string SettingPage = "SettingPage";
    private string MainMenu = "MainMenu";
    private string AboutPage = "AboutPage";

    public FadeAnimationSC fadeAnim;

    //Main Menu Buttons
    public void StartGame()
    {
        fadeAnim.FadeTo(LevelSelector);
        //sceneFader.FadeTo(LevelSelector);
        //SceneManager.LoadScene(LevelSelector);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        fadeAnim.FadeTo(SettingPage);
        //sceneFader.FadeTo(SettingPage);
    }

    public void GotoMainMenu()
    {
        fadeAnim.FadeTo(MainMenu);
    }

    public void About()
    {
        fadeAnim.FadeTo(AboutPage);
        //sceneFader.FadeTo(AboutPage);
    }
    //
}
