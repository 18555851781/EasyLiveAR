using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

namespace View
{
    public class View_LoginScene_ListButtonInput : MonoBehaviour
    {
        public void ShopButtonInput()
        {
            Control_LoginScene_ListButtonInput.Instance.ShopButtonInput();

        }

        public void ExitShopButooninput()
        {
            Control_LoginScene_ListButtonInput.Instance.ExitShopButtonInput();
        }

        public void ListButtonInput()
        {
            Control_LoginScene_ListButtonInput.Instance.ListButtonInput();

        }

        public void ExitListButtonInput()
        {
            Control_LoginScene_ListButtonInput.Instance.ExitListButtonInput();
        }

        public void DestroyButtonInput()
        {
            Control_LoginScene_ListButtonInput.Instance.DestroyButtonInput();
        }

        public void HelpButtonInput()
        {
            Control_LoginScene_HelpButtonInput.Instance.HelpButtonInput();
        }
        public void HelpExitbuttonInput()
        {
            Control_LoginScene_HelpButtonInput.Instance.HelpExitButtonInput();
        }
    }
}
