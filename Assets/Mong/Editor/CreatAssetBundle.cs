using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreatAssetBundle : MonoBehaviour
{

    [UnityEditor.MenuItem("Assets/Build All Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDir = "Assets/StreamingAssets";

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDir);
        }

        BuildPipeline.BuildAssetBundles(assetBundleDir, BuildAssetBundleOptions.None,
            EditorUserBuildSettings.activeBuildTarget);
    }
}
