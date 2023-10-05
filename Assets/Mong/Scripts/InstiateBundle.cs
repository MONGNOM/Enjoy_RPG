using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstiateBundle : MonoBehaviour
{
    public string bundleName;
    public string bundleName2;
    public string bundleName3;
    public string bundleName4;
    public string assetName;

    private void Start()
    {
        LoadFromLocalAsync();
    }
    public void LoadFromLocalAsync()
    {
        StartCoroutine(LoadFromLocalAsyncProcess());
    }

    private IEnumerator LoadFromLocalAsyncProcess()
    {
        AssetBundleCreateRequest asyncBundleRequest =
            AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName)); 
        AssetBundleCreateRequest BundleRequest =
            AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName2));
        AssetBundleCreateRequest Bundlesprite =
           AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName3));
        AssetBundleCreateRequest Bundlemat =
           AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName4));

        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("번들 로드 실패");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetWithSubAssetsAsync<GameObject>(assetName);
        yield return assetRequest;


        var prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(true);
    }
}
