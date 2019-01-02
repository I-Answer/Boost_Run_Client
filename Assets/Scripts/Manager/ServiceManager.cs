using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class ServiceManager : MonoBehaviour {

    public enum AdState {
        Video, RewardVideo
    }

    private const string androidId = "2974257";
    private const string iosId = "2974256";

    private const string videoKeys = "video";
    private const string rewardKeys = "rewardVideo";

    private static bool isInit;

    private void Awake() {
        if (isInit) return;

        isInit = true;

        DontDestroyOnLoad(gameObject);

#if UNITY_ADS
#if UNITY_ANDROID
        Advertisement.Initialize(androidId);
#elif UNITY_IOS
        Advertisement.Initialize(iosId);
#endif
#endif
    }

    public static void ShowAd(AdState adKey, float probability = 1f) {
#if UNITY_ADS
        if (!Advertisement.IsReady())
            return;

        if (Random.value < probability)
            Advertisement.Show(GetKey(adKey));
#endif
    }

    private static string GetKey(AdState adKey) {
        switch (adKey) {
            case AdState.Video:
                return videoKeys;

            case AdState.RewardVideo:
                return rewardKeys;
        }

        return rewardKeys;
    }
}
