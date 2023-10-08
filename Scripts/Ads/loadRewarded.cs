using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class loadRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;
    UnityAdsShowCompletionState ahmet;


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
        Debug.Log("Loading Rewarded Ad !");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(adUnitId))
        {
            Debug.Log("Rewarded Ad loaded !");
            ShowAd();
        }
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Rewarded Ad loading failed!");
    }


    public void ShowAd()
    {
        Debug.Log("Showing Rewarded Ad !");
        Advertisement.Show(adUnitId, this);
    }


    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Rewarded Ad clicked!");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //showCompletionState.Equals(UnityAdsCompletionState.COMPLETED) dont work, more search needed
        if (placementId.Equals(adUnitId))
        {
            Debug.Log("Rewarded Ad 1 show complete!");
            GameManager.Instance.Player.AddGems(100);
            UIManager.Instance.OpenShop(GameManager.Instance.Player.gems);
        }

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Rewarded Ad show failure!");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Rewarded Ad show start!");
    }

}

