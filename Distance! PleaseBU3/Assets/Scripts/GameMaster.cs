using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using GoogleMobileAds.Api;

public class GameMaster : MonoBehaviour
{
    public FadeAnimationSC fadeAnim;
    private string LevelSelector = "Level Selector";
    private string MainMenu = "MainMenu";
    private string SettingsPage = "SettingsPage";

    public AudioSource ThatsWinSound;
    public AudioSource GameOverSound;
    public AudioSource LevelAudio;
    public GameObject winPanel;
    public GameObject pauseMenuPanel;
    public GameObject restartPanel;
    public TMP_Text scoreText;
    public float timePassed = 10;
    private bool HasLost;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    private void Start()
    {
        RequestInterstitial();
    }
    private void Update()
    {
        if (!HasLost && timePassed > 0)
        {
            timePassed -= Time.deltaTime;
            scoreText.text = timePassed.ToString("F0");
            if(timePassed < 0)
            {
                //Win
                LevelAudio.Pause();
                ThatsWinSound.Play();
                Time.timeScale = 0.5f;
                winPanel.SetActive(true);

                if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
                {
                    PlayerPrefs.SetInt("levelReached", levelToUnlock);
                }
            }
        }
    }

    public void GameOver()
    {
        if (!winPanel.activeSelf)
        {
            Invoke("ShowAd", 0.5f); //Ad
            LevelAudio.Pause();
            HasLost = true;
            Invoke("Delay", 1f);
            pause();
        }
    }
//cont() is Container for the invoke of timeScale 
    void cont()
    {
        Time.timeScale = 0;
    }
    void pause()
    {
        Invoke("cont", 1f);
    }

    void Delay()
    {
        GameOverSound.Play();
        restartPanel.SetActive(true);
    }
//
    
    public void GamePaused()
    {
        ShowInterstitialAd();
        LevelAudio.Pause(); // AUDIO
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void GoToLevelSelect()
    {
        fadeAnim.FadeTo(LevelSelector);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {

        Time.timeScale = 1f;
        fadeAnim.FadeTo(MainMenu);
    }

    public void ResumeGame()
    {
        LevelAudio.UnPause();
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoToGame()
    {
        fadeAnim.FadeTo(LevelSelector);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(SettingsPage);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    //Ads

    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {

        string InterAdUnitId = "ca-app-pub-3940256099942544/1033173712";


        this.interstitial = new InterstitialAd(InterAdUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

    }


    private void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            Debug.Log("InterBoi Loaded"); //testing
        }
    }

    //Delay method For Ads

    void ShowAd()
    {
        ShowInterstitialAd();
    }
}
