using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using UnityEngine.InputSystem.Android;
//using UnityEngine.InputSystem;

public class loadBanner : MonoBehaviour
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

        Advertisement.Banner.SetPosition(bannerPosition);
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions {
            loadCallback=OnBannerLoaded,
            errorCallback=OnBannerLoadError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    void OnBannerLoaded()
    {
        Debug.Log("Banner Loaded !");
        showBannerAd();
    }

    void OnBannerLoadError(string error)
    {
        Debug.Log("Banner Failed To Load: " + error);
    }

    public void showBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback=OnBannerShown,
            clickCallback=OnBannerClicked,
            hideCallback=OnBannerHidden
        };

        Advertisement.Banner.Show(adUnitId, options);
    }

    void OnBannerShown() { }
    void OnBannerClicked() { }
    void OnBannerHidden() { }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}
