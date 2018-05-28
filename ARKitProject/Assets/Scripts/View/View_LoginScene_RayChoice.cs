using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using Control;

namespace View
{
    public class View_LoginScene_RayChoice : MonoBehaviour
    {
        
        void Start()
        {

        }

        void Update()
        {
            //  射线选取物体  

            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit MyHit;

                if(Physics.Raycast(ray,out MyHit))
                {
                    if(MyHit.transform.gameObject!=null && MyHit.transform.tag=="Model")
                    {
                        foreach (var item in Control.Control_LoginScene_ObjectInstance.Instance.ArrayGameObject)
                        {
                            item.GetComponent<UnityARHitTestExample>().enabled = false;
                        }

                        MyHit.transform.GetComponent<UnityARHitTestExample>().enabled = true;
                    }
                }
            }


        }
    }
}
