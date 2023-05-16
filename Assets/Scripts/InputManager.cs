using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class InputManager
{
    private static int _money;

    public static int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }
}
