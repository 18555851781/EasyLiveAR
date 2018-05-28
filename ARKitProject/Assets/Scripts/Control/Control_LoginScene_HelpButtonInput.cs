using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Control
{
    public class Control_LoginScene_HelpButtonInput : MonoBehaviour
    {

        public static Control_LoginScene_HelpButtonInput Instance;
        private Transform HelpPlane;
        private bool IsInput;

		private void Awake()
		{
            Instance = this;
		}

		private void Start()
		{
            HelpPlane = GameObject.Find("HelpWord_Plane").transform;
		}

		void Update()
        {
            if(IsInput)
            {
                HelpPlane.localPosition = Vector3.Lerp(HelpPlane.localPosition, new Vector3(0,0,0), 0.2f);
                Control_LoginScene_ListButtonInput.Instance.IsShopButtonMove = false;
                Control_LoginScene_ListButtonInput.Instance.IsListButtonMove = false;
            }else
            {
                HelpPlane.localPosition = Vector3.Lerp(HelpPlane.localPosition, new Vector3(0, 2000, 0), 0.2f);
            }
        }

        public void HelpButtonInput()
        {
            IsInput = true;
        }
        public void HelpExitButtonInput()
        {
            IsInput = false;
        }
    }
}
