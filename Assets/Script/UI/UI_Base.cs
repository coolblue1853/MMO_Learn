using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    public abstract void Init();
    private void Start()
    {
        Init();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[name.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            //게임오브젝트 찾기
            if (typeof(T) == typeof(GameObject))
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            else // 특정 컴포넌트 찾기
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
            if (objects[i] == null)
                Debug.Log($"Failed to bind{names[i]}");
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }
    protected GameObject GetGameObject(int idx){return Get<GameObject>(idx);}
    protected Text GetText(int idx){return Get<Text>(idx);}
    protected Button GetButton(int idx){return Get<Button>(idx);}
    protected Image GetImage(int idx){return Get<Image>(idx);}

    public static void BindEvent(GameObject go, Action<PointerEventData> action,Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(go);
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.onClickHandler -= action;
                evt.onClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.onDragHandler -= action;
                evt.onDragHandler += action;
                break;
        }
    }
}
