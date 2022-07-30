using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition _bannerPosition;

    [SerializeField] private string _androidAdUnitId = "Banner_Android";
    [SerializeField] private string _iOSAdUnitId = "Banner_iOS";

    private string _adUnitId;

    private void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(_bannerPosition);
        StartCoroutine(LoadAdBanner());
    }

    private IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(3f);
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_adUnitId, options);
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(_adUnitId, options);  
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void OnBannerClicked() { }
    private void OnBannerShown() { }
    private void OnBannerHidden() { }
}
