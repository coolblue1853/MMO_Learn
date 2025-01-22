using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    //Ư�� ������Ʈ�� �������ų� ������ �����
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    // ���ӿ�����Ʈ ã��(������ Ʈ�������� ������ ����
    public static GameObject FindChild(GameObject go, string name = null, bool recuresive = false)
    {
        Transform  transform = FindChild<Transform>(go, name, recuresive);
        if (transform == null) return null;

        return transform.gameObject;
    }
    // �ڽļ�ȸ�ؼ� ������Ʈ ã��
    public static T FindChild<T>(GameObject go, string name = null, bool recuresive = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if(recuresive == false) // �ڽ��� �ڽı��� �����ΰ�
        {
            for(int i =0; i< go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component =  transform.GetComponent<T>();
                    return component;
                }
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}
