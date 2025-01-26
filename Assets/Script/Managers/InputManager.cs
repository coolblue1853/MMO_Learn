using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class InputManager
{
    public Action KeyAciton = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;
    float _pressedTime;
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // UI Ŭ���� Ȯ��
            return;

        if (Input.anyKey && KeyAciton != null)
            KeyAciton.Invoke();

        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (!_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.PointerDown);
                    _pressedTime = Time.time;
                }
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                {
                    if(Time.time < _pressedTime + 0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);
                    MouseAction.Invoke(Define.MouseEvent.PointerUp);

                }
                    
                _pressed = false;
                _pressedTime = 0;
            }
        }
    }

    public void Clear()
    {
        KeyAciton = null;
        MouseAction = null;
    }
}
