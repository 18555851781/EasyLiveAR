using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.iOS;

namespace Control
{
    public class Control_LoginScene_ListButtonInput : MonoBehaviour
    {
        public static Control_LoginScene_ListButtonInput Instance;

        public Transform ButtonList;

        public Transform ShopMenu;

        public Transform ListMenu;

        private Transform HelpPlane;

        public bool IsShopButtonMove;

        public bool IsListButtonMove;

        public Dictionary<string, float> PledgeMoney = new Dictionary<string, float>();        //  押金数组

        public Dictionary<string, float> Chartermoney = new Dictionary<string, float>();       //  租金数组

        public Text Pledge;

        public Text Charter;

		string iP_genneration;

		private void Awake()
		{
            Instance = this;
        }

        void Start()
        {
            HelpPlane = GameObject.Find("HelpWord_Plane").transform;

            MoneyAdd();

            Debug.Log(UnityEngine.iOS.Device.generation);
            
			iP_genneration = UnityEngine.iOS.Device.generation.ToString();
        }

        //  在Update里面实时更新List状态

        void Update()
        {

            if (IsShopButtonMove)
            {
				if (iP_genneration.Substring(0,3)=="iPa")
                {
                    ButtonMenuMoveDown();
                    ShopMenuMoveUp();
				}
				else if(UnityEngine.iOS.Device.generation==UnityEngine.iOS.DeviceGeneration.iPhoneX)
                {
					ButtonMenuMoveDown();
					IphoneXShopMenuMoveUp();
				}
				else
				{
					ButtonMenuMoveDown();
                    IphoneShopMenuMoveUp();
				}
            }
            else
            {
                ButtonMenuMoveUp();
                ShopMenuMoveDown();
            }

            if(IsListButtonMove)
            {
                if (iP_genneration.Substring(0, 3) == "iPa")
                {
                    ButtonMenuMoveDown();
                    ListMenuMoveUp();
				}
				else if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneX)
                {
					ButtonMenuMoveDown();
					IphoneXListMenuMoveUp();
				}
				else
				{
					ButtonMenuMoveDown();
                    IphoneListMenuMoveUp();
				}
            }
            else
            {
                ButtonMenuMoveUp();
                ListMenuMoveDown();
            }
        }

        //  改变菜单  按钮的位置  适用Lerp渐变

        private void ButtonMenuMoveDown()
        {
            ButtonList.transform.localPosition = Vector3.Lerp(ButtonList.transform.localPosition, new Vector3(0, -400, 0), 0.2f);
        }
        private void ButtonMenuMoveUp()
        {
            ButtonList.transform.localPosition = Vector3.Lerp(ButtonList.transform.localPosition, new Vector3(0, -100, 0), 0.2f);
        }
        private void ShopMenuMoveDown()
        {
            ShopMenu.transform.localPosition = Vector3.Lerp(ShopMenu.transform.localPosition, new Vector3(0, -1050, 0), 0.2f);
        }
        private void ListMenuMoveDown()
        {
            ListMenu.transform.localPosition = Vector3.Lerp(ListMenu.transform.localPosition, new Vector3(0, -1220, 0), 0.2f);
        }

        private void ShopMenuMoveUp()
        {
            ShopMenu.transform.localPosition = Vector3.Lerp(ShopMenu.transform.localPosition, new Vector3(0, -420, 0), 0.2f);
        }
        private void IphoneShopMenuMoveUp()
        {
			ShopMenu.transform.localPosition = Vector3.Lerp(ShopMenu.transform.localPosition, new Vector3(0, -600, 0), 0.2f);
        }
		private void IphoneXShopMenuMoveUp()
		{
			ShopMenu.transform.localPosition = Vector3.Lerp(ShopMenu.transform.localPosition, new Vector3(0, -750, 0), 0.2f);
		}

        private void ListMenuMoveUp()
        {
            ListMenu.transform.localPosition = Vector3.Lerp(ListMenu.transform.localPosition, new Vector3(0, -240, 0), 0.2f);
        }
        private void IphoneListMenuMoveUp()
        {
			ListMenu.transform.localPosition = Vector3.Lerp(ListMenu.transform.localPosition, new Vector3(0, -420, 0), 0.2f);
            
        }
		private void IphoneXListMenuMoveUp()
        {
			ListMenu.transform.localPosition = Vector3.Lerp(ListMenu.transform.localPosition, new Vector3(0, -570, 0), 0.2f);
        }





        //  控制是否进行List变化的Bool值  

        public void ShopButtonInput()
        {
            HelpPlaneInputReturn();
            IsShopButtonMove = true;
        }

        //  退出商店按钮按下时 bool变为false
        public void ExitShopButtonInput()
        {
            IsShopButtonMove = false;
        }

        //  在清单按钮按下时  同时计算押金和租金数量

        public void ListButtonInput()
        {
            HelpPlaneInputReturn();
            IsListButtonMove = true;
            PledgeMoneyAll();
            ChartermoneyAll();
        }

        //  退出清单按钮按下时Bool变为false

        public void ExitListButtonInput()
        {
            IsListButtonMove = false;
        }


        //  点击删除按钮  将物体删除  同时将物体从数组中移除  同时将订单数组中的按钮去除

        public void DestroyButtonInput()
        {
            HelpPlaneInputReturn();

            foreach (var item in Control_LoginScene_ObjectInstance.Instance.ArrayGameObject)
            {
                if(item.GetComponent<UnityARHitTestExample>().enabled==true)
                {
                    Destroy(item.gameObject);

                    Control_LoginScene_ObjectInstance.Instance.ArrayGameObject.Remove(item);

                    foreach (var button in Control_LoginScene_ObjectInstance.Instance.MenuList_Button)
                    {
                        if(string.Equals(item.name,button.name+"(Clone)"))
                        {
                            button.SetActive(false);
                        }
                    }
                }
            }
        }

        //  计算总押金值

        public void PledgeMoneyAll()
        {
            Pledge.text = "0";

            foreach (var ObjName in Control_LoginScene_ObjectInstance.Instance.ArrayGameObject)
            {
                foreach (var Ple in PledgeMoney)
                {
                    if(ObjName.name==Ple.Key)
                    {
                        float Money = float.Parse(Pledge.text) + Ple.Value;

                        Pledge.text = Money.ToString();
                    }
                }
            }


        }

        //  计算总租金值

        public void ChartermoneyAll()
        {
            Charter.text = "0";

            foreach (var ObjName in Control_LoginScene_ObjectInstance.Instance.ArrayGameObject)
            {
                foreach (var Cha in Chartermoney)
                {
                    if (ObjName.name == Cha.Key)
                    {
                        float Money = float.Parse(Charter.text) + Cha.Value;

                        Charter.text = Money.ToString();
                    }
                }
            }
        }

        private void HelpPlaneInputReturn()
        {
            if (HelpPlane.transform.localPosition.y >= 0 && HelpPlane.transform.localPosition.y <= 100)
            {
                return;
            }
        }

        private void MoneyAdd()
        {
            PledgeMoney.Add("Bed(Clone)", 197.5f);
            Chartermoney.Add("Bed(Clone)", 24.98f);
            PledgeMoney.Add("BedSide(Clone)", 35f);
            Chartermoney.Add("BedSide(Clone)", 4.42f);
            PledgeMoney.Add("BigTable(Clone)", 75f);
            Chartermoney.Add("BigTable(Clone)", 9.48f);
            PledgeMoney.Add("BlackRoundTable(Clone)", 95f);
            Chartermoney.Add("BlackRoundTable(Clone)", 12.01f);
            PledgeMoney.Add("Chair(Clone)", 25f);
            Chartermoney.Add("Chair(Clone)", 3.16f);
            PledgeMoney.Add("Desk(Clone)", 47.5f);
            Chartermoney.Add("Desk(Clone)", 6f);
            PledgeMoney.Add("EatTable(Clone)", 87.5f);
            Chartermoney.Add("EatTable(Clone)", 11.06f);
            PledgeMoney.Add("FourDoorWardrode(Clone)", 225);
            Chartermoney.Add("FourDoorWardrode(Clone)", 28.46f);
            PledgeMoney.Add("IronBed(Clone)", 175);
            Chartermoney.Add("IronBed(Clone)", 22.13f);
            PledgeMoney.Add("IronBedSide(Clone)", 37.5f);
            Chartermoney.Add("IronBedSide(Clone)", 4.74f);
            PledgeMoney.Add("IronDesk(Clone)", 75f);
            Chartermoney.Add("IronDesk(Clone)", 9.48f);
            PledgeMoney.Add("IronStacks(Clone)", 215f);
            Chartermoney.Add("IronStacks(Clone)", 27.19f);
            PledgeMoney.Add("IronTeatable(Clone)", 65f);
            Chartermoney.Add("IronTeatable(Clone)", 8.22f);
            PledgeMoney.Add("IronTV Cabinet(Clone)", 60f);
            Chartermoney.Add("IronTV Cabinet(Clone)", 7.59f);
            PledgeMoney.Add("OneSofa(Clone)", 125f);
            Chartermoney.Add("OneSofa(Clone)", 15.81f);
            PledgeMoney.Add("Shoe(Clone)", 72.5f);
            Chartermoney.Add("Shoe(Clone)", 9.17f);
            PledgeMoney.Add("TeaTable(Clone)", 55f);
            Chartermoney.Add("TeaTable(Clone)", 6.95f);
            PledgeMoney.Add("ThreeDoorWardrode(Clone)", 195f);
            Chartermoney.Add("ThreeDoorWardrode(Clone)", 24.66f);
            PledgeMoney.Add("ThreeSofa(Clone)", 287.5f);
            Chartermoney.Add("ThreeSofa(Clone)", 36.36f);
            PledgeMoney.Add("TV Cabinet(Clone)", 75f);
            Chartermoney.Add("TV Cabinet(Clone)", 9.48f);
            PledgeMoney.Add("TwoDoorWardrode(Clone)", 155f);
            Chartermoney.Add("TwoDoorWardrode(Clone)", 19.6f);
            PledgeMoney.Add("TwoSofa(Clone)", 197.5f);
            Chartermoney.Add("TwoSofa(Clone)", 24.98f);
            PledgeMoney.Add("WhiteRoundTable(Clone)", 96f);
            Chartermoney.Add("WhiteRoundTable(Clone)", 12.01f);
            PledgeMoney.Add("WoodBedside(Clone)", 40f);
            Chartermoney.Add("WoodBedside(Clone)", 5.06f);
            PledgeMoney.Add("WoodDesk(Clone)", 82.5f);
            Chartermoney.Add("WoodDesk(Clone)", 10.43f);
            PledgeMoney.Add("WoodFourDoorWardrode(Clone)", 275f);
            Chartermoney.Add("WoodFourDoorWardrode(Clone)", 34.78f);
            PledgeMoney.Add("WoodShoe(Clone)", 95f);
            Chartermoney.Add("WoodShoe(Clone)", 12.01f);
            PledgeMoney.Add("WoodTeaTable(Clone)", 112.5f);
            Chartermoney.Add("WoodTeaTable(Clone)", 14.23f);
            PledgeMoney.Add("WoodThreeDoorWardrode(Clone)", 222f);
            Chartermoney.Add("WoodThreeDoorWardrode(Clone)", 27.83f);
            PledgeMoney.Add("WoodTVCabinet(Clone)", 75f);
            Chartermoney.Add("WoodTVCabinet(Clone)", 9.48f);
            PledgeMoney.Add("WoodTwoDoorWardrode(Clone)", 155f);
            Chartermoney.Add("WoodTwoDoorWardrode(Clone)", 19.6f);


            PledgeMoney.Add("OneSofa1(Clone)", 180f);
            Chartermoney.Add("OneSofa1(Clone)", 22.77f);
            PledgeMoney.Add("OneSofa2(Clone)", 195f);
            Chartermoney.Add("OneSofa2(Clone)", 24.66f);
            //PledgeMoney.Add("OneSofa3(Clone)", 187.5f);
            //Chartermoney.Add("OneSofa3(Clone)", 23.71f);
            PledgeMoney.Add("WoodBedSide1(Clone)", 37.5f);
            Chartermoney.Add("WoodBedSide1(Clone)", 4.74f);
            PledgeMoney.Add("WoodBedSide2(Clone)", 100f);
            Chartermoney.Add("WoodBedSide2(Clone)", 12.65f);
            PledgeMoney.Add("WoodBedSide3(Clone)", 100f);
            Chartermoney.Add("WoodBedSide3(Clone)", 12.65f);
            PledgeMoney.Add("WoodBookrack(Clone)", 300f);
            Chartermoney.Add("WoodBookrack(Clone)", 37.95f);
            PledgeMoney.Add("WoodCabinet(Clone)", 500f);
            Chartermoney.Add("WoodCabinet(Clone)", 63.25f);
            PledgeMoney.Add("WoodCloset1(Clone)", 700f);
            Chartermoney.Add("WoodCloset1(Clone)", 88.55f);
            PledgeMoney.Add("WoodCloset2(Clone)", 1050f);
            Chartermoney.Add("WoodCloset2(Clone)", 132.82f);
            PledgeMoney.Add("WoodDesk2(Clone)", 162.5f);
            Chartermoney.Add("WoodDesk2(Clone)", 20.55f);
            PledgeMoney.Add("WoodDiningTable1(Clone)", 625f);
            Chartermoney.Add("WoodDiningTable1(Clone)", 79.06f);
            PledgeMoney.Add("WoodDiningTable2(Clone)", 675f);
            Chartermoney.Add("WoodDiningTable2(Clone)", 85.38f);
            PledgeMoney.Add("WoodTVCabinet1(Clone)", 500f);
            Chartermoney.Add("WoodTVCabinet1(Clone)", 63.25f);
            PledgeMoney.Add("WoodTVCabinet2(Clone)", 350f);
            Chartermoney.Add("WoodTVCabinet2(Clone)", 44.27f);
            PledgeMoney.Add("WoodBookrack2(Clone)", 375f);
            Chartermoney.Add("WoodBookrack2(Clone)", 47.43f);
            PledgeMoney.Add("WoodChest(Clone)", 525f);
            Chartermoney.Add("WoodChest(Clone)", 66.41f);
            PledgeMoney.Add("WoodDresser(Clone)", 300f);
            Chartermoney.Add("WoodDresser(Clone)", 37.95f);
        }

    }
}
