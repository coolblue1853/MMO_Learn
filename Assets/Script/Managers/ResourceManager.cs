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
        // .�������ʸ� �̹� ��� ������ �ٷ� ���
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load Prefab : {path}");
        }

        // Ȥ�� Ǯ���� �� �༮�� �ִ°�?
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    public void Destroy(GameObject ob)
    {
        if (ob == null) return;

        // ���� Ǯ���� �ʿ��� �༮�̸� Ǯ�� �Ŵ����� ��ȯ�Ұ��ΰ�

        Object.Destroy(ob);
    }
}
