using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // .오리지너를 이미 들고 있으면 바로 사용
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load Prefab : {path}");
        }

        // 혹시 풀링이 된 녀석이 있는가?
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    public void Destroy(GameObject ob)
    {
        if (ob == null) return;

        // 만약 풀링이 필요한 녀석이면 풀링 매니저에 반환할것인가

        Object.Destroy(ob);
    }
}
