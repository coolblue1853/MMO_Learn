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
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load Prefab : {path}");
        }
        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject ob)
    {
        if (ob == null) return;
        Object.Destroy(ob);
    }
}
