using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId;
    public string iosGameID;

    public bool isTestingMode = false;

    string gameId;

    private void Awake()
    {
        InitalizeAds();
    }

    void InitalizeAds()
    {
#if UNITY_ANDROID
        gameId = androidGameId;
#elif UNÝTY_IOS
        gameId = iosGameID;
#elif UNÝTY_EDÝTOR
        gameId = androidGameId; //for testing
#endif

        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Initialized succesfuly!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Failed To Initialize Ads!");
    }
}
