using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTJ
{

    public class DynamicResolutionManager : MonoBehaviour
    {
        float widthScale  = 1.0f;
        float heightScale = 1.0f;


        public void OnValueChangeWidth(float value)
        {
           widthScale = value;
            ScalableBufferManager.ResizeBuffers(widthScale, heightScale);
        }


        public void OnValueChangeHeight(float value)
        {
            heightScale = value;
            ScalableBufferManager.ResizeBuffers(widthScale, heightScale);
        }
    }
}
