using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdController : MonoBehaviour, IUnityAdsListener
{
    private string playStoreId = "3812031";
    //private string appStoreId = "3812030";

    private static string videoAd = "video";
    private static string rewardedVideoAd = "rewardedVideo";

    private void Start()
    {
        Advertisement.Initialize(playStoreId, true);
    }

    public static void PlayVideoAd()
    {
        if (Advertisement.IsReady(videoAd))
            Advertisement.Show(videoAd);
    }

    public static void PlayRewardedVideoAd()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
            Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {

                }
                break;
        }
    }
}
