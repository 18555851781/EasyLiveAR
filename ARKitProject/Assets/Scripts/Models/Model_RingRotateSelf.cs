using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Model_RingRotateSelf : MonoBehaviour
    {


        void Start()
        {

        }


        void Update()
        {
            if (this.gameObject.activeSelf == true)
            {
                transform.localEulerAngles += new Vector3(0, 1, 0);
            }
        }
    }
}
