using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.iOS;

namespace Control
{

    public class Control_LoginScene_ObjectInstance : MonoBehaviour
    {

        public List<GameObject> ArrayGameObject = new List<GameObject>();

        public static Control_LoginScene_ObjectInstance Instance;

        private GameObject MyObj;

        GameObject MenuList_Connect;     //  订单按钮的父物体

        GameObject ListMenu;        

        public List<GameObject> MenuList_Button = new List<GameObject>();       //  存放按钮的数组

		private void Awake()
		{
            Instance = this;

            ListMenu = GameObject.Find("MenuList");

            //  循环将子物体加入数组

            MenuList_Connect = GameObject.Find("ContentMenuList");

            for (int i = 0; i < MenuList_Connect.transform.childCount; i++)
            {
                MenuList_Button.Add(MenuList_Connect.transform.GetChild(i).gameObject);
            }
		}

		public void Control_InputButtonDown()
        {
            //  将数组中的GameObject组件关闭

            foreach (var item in ArrayGameObject)
            {
                item.GetComponent<UnityARHitTestExample>().enabled = false;
            }

            //  点击按钮  获得名称

            string ButtonName = EventSystem.current.currentSelectedGameObject.name;

            //  查找数组中有没有相同的物体  若有则获得  没有则创建

            if (!GameObject.Find(ButtonName+"(Clone)"))
            {
                GameObject Models = Resources.Load(ButtonName) as GameObject;

                MyObj = Instantiate(Models,new Vector3(0,100,0),Quaternion.identity) as GameObject;

                ArrayGameObject.Add(MyObj);
            }
            else
            {
                GameObject.Find(ButtonName + "(Clone)").GetComponent<UnityARHitTestExample>().enabled = true;

            }

            //  改变Control_LoginScene_ListButtonInput中控制菜单上下移动的Bool值

            Control_LoginScene_ListButtonInput.Instance.IsShopButtonMove = false;

            Control_LoginScene_ListButtonInput.Instance.IsListButtonMove = false;

            //  循环查找是否有名称相同的按钮  有则将按钮为true

            foreach (var item in MenuList_Button)
            {
                foreach (var ObjName in ArrayGameObject)
                {
                    if (string.Equals(item.name + "(Clone)", ObjName.name))
                    {
                        item.SetActive(true);

                        item.transform.SetSiblingIndex(0);
                    }
                }
            }
        }

    }
}
