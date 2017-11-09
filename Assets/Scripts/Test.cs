using UnityEngine;
using Tangzx.ABSystem;
using System.Collections.Generic;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    AssetBundleManager manager;
    GameObject cube;
    GameObject image;
    void Start()
    {
        manager = gameObject.AddComponent<AssetBundleManager>();
        manager.Init(() =>
        {
            LoadObjects();
        });
    }

    void LoadObjects()
    {
        manager.Load("Assets.Prefabs.Sphere.prefab", (a) =>
        {
            GameObject go = Instantiate(a.mainObject) as GameObject;//a.Instantiate();
            go.transform.localPosition = new Vector3(3, 3, 3);
        });
        manager.Load("Assets.Prefabs.Cube.prefab", (a) =>
        {
            cube = a.Instantiate();
            cube.transform.localPosition = new Vector3(6, 3, 3);
        });
        manager.Load("Assets.Prefabs.Plane.prefab", (a) =>
        {
            GameObject go = a.Instantiate();
            go.transform.localPosition = new Vector3(9, 3, 3);
        });
        manager.Load("Assets.Prefabs.Capsule.prefab", (a) =>
        {
            GameObject go = a.Instantiate();
            go.transform.localPosition = new Vector3(12, 3, 3);
        });
        

    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100),""))
        {
            manager.Load("Assets.Prefabs.qiufen-005.jpg", (a) =>
            {
                Sprite xx = a.mainObject as Sprite;
                Sprite yy = cube.GetComponent<refxx>().spritess[0];
                cube.GetComponent<refxx>().spritess[0] = xx;
            });
            foreach (var kv in manager._loadedAssetBundle)
            {
                Debug.LogError(kv.Value.data.debugName);
            }

            //GameObject.Find("Image").GetComponent<Image>().sprite = cube.GetComponent<refxx>().spritess[0];
            //GameObject.Find("Image").GetComponent<Image>().sprite = null;
        }
        if (GUI.Button(new Rect(200, 100, 100, 100), ""))
        {
            List<AssetBundleInfo> temp = new List<AssetBundleInfo>();
            foreach (var kv in manager._loadedAssetBundle)
            {
                temp.Add(kv.Value);
            }
            for (int i = 0; i < temp.Count;i++ )
            {
                manager.RemoveBundleInfo(temp[i]);
            }
            Resources.UnloadUnusedAssets();
        }
        if (GUI.Button(new Rect(300, 100, 100, 100), ""))
        {
            cube.GetComponent<MeshRenderer>().material.mainTexture = cube.GetComponent<refxx>().textures[0];
        }
    }
}