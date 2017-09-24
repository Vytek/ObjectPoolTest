using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPreload : MonoBehaviour {

    public GameObject PrefabCube;
    public GameObject PrefabSphere;

    void Start()
    {
        this.PreloadGameObjectsIntoPool();
    }

    private void PreloadGameObjectsIntoPool()
    {
        GameObjectPooler.Instance.PreloadGameObject(PrefabCube);
        GameObjectPooler.Instance.PreloadGameObject(PrefabSphere);
    }
}
