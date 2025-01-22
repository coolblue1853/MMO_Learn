using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    //특정 컴포넌트를 가져오거나 없으면 만들기
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    // 게임오브젝트 찾기(무조건 트랜스폼을 가지고 있음
    public static GameObject FindChild(GameObject go, string name = null, bool recuresive = false)
    {
        Transform  transform = FindChild<Transform>(go, name, recuresive);
        if (transform == null) return null;

        return transform.gameObject;
    }
    // 자식순회해서 컴포넌트 찾기
    public static T FindChild<T>(GameObject go, string name = null, bool recuresive = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if(recuresive == false) // 자식의 자식까지 볼것인가
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
