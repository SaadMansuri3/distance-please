using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AdMobSC : MonoBehaviour
{

    //string AppID = "ca-app-pub-9283023250994843~4960108719";

    //string bannerAdID = "ca-app-pub-3940256099942544/6300978111";
    //string interstitialAdID = "ca-app-pub-3940256099942544/1033173712";


    private BannerView bannerView;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        
    }

    private void RequestBanner()
    {

        string BannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";

        this.bannerView = new BannerView(BannerAdUnitId, AdSize.Banner, AdPosition.Top);


        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;


        if(SceneManager.GetActiveScene().name == "Level Selector")
        {
            ShowBannerBoi();
            Debug.Log("BannerBoiShown");
        }
        

    }



    private void ShowBannerBoi()
    {
        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

        Debug.Log("BannerBoi Shown");
    }


    
    void OnDestroy()
    {
        bannerView.Destroy();
    }



    //For Events
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }









}



//APP ID = ca-app-pub-9283023250994843~4960108719
//string appId = "ca - app - pub - 9283023250994843~4960108719";
//string BannerAdID = "ca-app-pub-3940256099942544/6300978111";
//string InterstitialAdID = "ca-app-pub-3940256099942544/1033173712";