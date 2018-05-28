using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Control
{
    public class Control_LoginScene_StartPlaneClose : MonoBehaviour
    {

        public static Control_LoginScene_StartPlaneClose Instance;

        public Image StartPlane;

        public Image StartButton;

        bool IsChange;

        float times;

		private void Awake()
		{
            Instance = this;
		}

        //  开始界面以及字体渐变  2S后关闭开始界面

		private void Update()
		{
            if(IsChange)
            {
                times += Time.deltaTime;
                StartPlane.color = Color.Lerp(StartPlane.color, new Color(255, 255, 255, 0), 0.1f);
                StartButton.color = Color.Lerp(StartButton.color, new Color(255, 255, 255, 0), 0.1f);
                if(times>=2)
                {
                    IsChange = false;
                    StartPlane.gameObject.SetActive(false);
                }
            }
		}

        //  开始方法调用

		public void StartButtonDown()
		{
            IsChange = true;
		}

	}
}
