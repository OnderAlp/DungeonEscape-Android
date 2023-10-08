using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class loadInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    private void Start()
    {
#if UNITY_ANDROID
        adUnitId = androidAdUnitId;
#elif UNÝTY_IOS
        adUnitId = iosAdUnitId;
#endif

    }

    public void LoadAd()
    {
        Debug.Log("Loading Interstitial !");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial loaded !");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Interstitial loading failed!");
    }


    public void ShowAd()
    {
        Debug.Log("Showing Ad !");
        Advertisement.Show(adUnitId, this);
    }


    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Interstitial clicked!");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Interstitial show complete!");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Interstitial show failure!");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Interstitial show start!");
    }
}
