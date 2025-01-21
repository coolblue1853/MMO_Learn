using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class InputManager
{
    public Action KeyAciton = null;
    public Action<Define.MousEvent> MouseAction = null;
    bool _pressed = false;
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // UI 클릭시 확인
            return;

        if (Input.anyKey && KeyAciton != null)
            KeyAciton.Invoke();

        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MousEvent.Press);
                _pressed = true;
            }
            else
            {
                if(_pressed)
                    MouseAction.Invoke(Define.MousEvent.Click );
                _pressed = false;
            }
        }


    }
}
