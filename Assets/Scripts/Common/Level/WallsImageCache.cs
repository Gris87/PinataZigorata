#define WALLS_IMAGE_CACHE_DEBUG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallsImageCache
{
    public static List<string>               images;
    public static Dictionary<string, Sprite> cachedSprites;

    private static IEnumerator startLoadingStreamingAssets()
    {
#if WALLS_IMAGE_CACHE_DEBUG
        Debug.Log("Streaming assets path : " + Application.streamingAssetsPath);
#endif

        string listFilePath = Application.streamingAssetsPath + "/Walls/_list.txt";
        string[] images;

#if WALLS_IMAGE_CACHE_DEBUG
        Debug.Log("List file path : " + listFilePath);
#endif

        yield return new WaitForSeconds(1);
    }

    static WallsImageCache()
    {
        images        = new List<string>();
        cachedSprites = new Dictionary<string, Sprite>();

        WallsImageCacheOwner.owner.StartCoroutine(startLoadingStreamingAssets());
    }
}
