using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

namespace View
{
    public class View_LoginScene_InstacneButton : MonoBehaviour
    {

        public void LoginScene_InputModelsButton()
        {
            Control_LoginScene_ObjectInstance.Instance.Control_InputButtonDown();
        }
    }
}
