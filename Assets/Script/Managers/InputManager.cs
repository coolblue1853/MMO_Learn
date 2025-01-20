using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager
{
    public Action keyAciton = null;
    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;

        if (keyAciton != null)
            keyAciton.Invoke();
    }
}
