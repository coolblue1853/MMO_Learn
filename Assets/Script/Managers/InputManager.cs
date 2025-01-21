using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager
{
    public Action KeyAciton = null;
    public Action<Define.MousEvent> MouseAction = null;
    bool _pressed = false;
    public void OnUpdate()
    {
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
