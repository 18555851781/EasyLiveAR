using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
	public class UnityARGeneratePlane : MonoBehaviour
	{
        private UnityARAnchorManager unityARAnchorManager;

		// Use this for initialization
		void Start ()   
        {
            unityARAnchorManager = new UnityARAnchorManager();
			
		}

        void OnDestroy()
        {
            unityARAnchorManager.Destroy ();
        }

	}
}

