using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Inven_Item : UI_Base
{
    enum GamoObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GamoObjects));
        Get<GameObject>((int)GamoObjects.ItemNameText).GetComponent<Text>().text = "테스트";

        Get<GameObject>((int)GamoObjects.ItemIcon).BindEvent
            ((PointerEventData) => { Debug.Log($"아이템 출력 : {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
