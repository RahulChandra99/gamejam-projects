using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    AssetBundle myLoadedAssetBundle;

    public string assetUN;

    public string path;


    void Start()
    {
        LoadAssetBundles(path);
        InstantiateObjectFromBundle(assetUN);
    }

    void LoadAssetBundles(string bundleUrl)
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile(bundleUrl);

        Debug.Log(myLoadedAssetBundle == null ? " Failed to load Asset Bundle" : "Assetbundle success");
    }

    void InstantiateObjectFromBundle(string assetName)
    {
        var prefab = myLoadedAssetBundle.LoadAsset(assetName);
        Instantiate(prefab);
    }

}
