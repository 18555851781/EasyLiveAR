using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

namespace Control
{
    public class Control_Model_RingActive : MonoBehaviour
    {
        //  获取到物体上挂载的AR脚本

        UnityARHitTestExample ARScript;

        void Start()
        {
            ARScript = GetComponent<UnityARHitTestExample>();
        }

        void Update()
        {
            //  模型下方选中框进行自旋转

            if(ARScript.enabled==false)
            {
                transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
            }else
            {
                transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
            }
        }
    }
}
