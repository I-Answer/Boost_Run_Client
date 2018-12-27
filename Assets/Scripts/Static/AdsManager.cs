using UnityEngine.Advertisements;

public static class AdsManager {

    public enum AdState {
        Video, RewardVideo
    }

    private const string videoKeys = "video";
    private const string rewardKeys = "rewardVideo";

	public static void ShowAd(AdState adKey) {
        if (!Advertisement.IsReady(GetKey(adKey)))
            return;

        Advertisement.Show(GetKey(adKey));
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
