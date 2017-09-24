using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPreload : MonoBehaviour {

    public GameObject PrefabCube;
    public GameObject PrefabSphere;
    private GameObject CylinderPrefab;

    void Start()
    {
        this.PreloadGameObjectsIntoPool();
    }

    private void PreloadGameObjectsIntoPool()
    {
        GameObjectPooler.Instance.PreloadGameObject(PrefabCube);
        GameObjectPooler.Instance.PreloadGameObject(PrefabSphere);
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.SetActive(false);
        GameObjectPooler.Instance.AddToObjectPool(cylinder, cylinder.name);
        GameObjectPooler.Instance.PreloadGameObject(cylinder);
        StartCoroutine(SpawnLargeClouds());
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-5, 5),
            Random.Range(-5, 5),
            Random.Range(-5, 5));
    }

    IEnumerator SpawnLargeClouds()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            var largeCloud = GameObjectPooler.Instance.GetObject(PrefabCube);
            largeCloud.transform.position = GetRandomPosition();
            largeCloud.transform.rotation = Quaternion.identity;
            largeCloud.SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }
}
