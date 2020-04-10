using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UTJ
{

    public class FrameTimingUI : MonoBehaviour
    {                
        [SerializeField] Text uiText;

        FrameTiming[] frameTimings;
        int frameCount;

        private void Start()
        {
            frameTimings = new FrameTiming[3];
            frameCount = 0;
        }


        // Update is called once per frame
        void Update()
        {
            ++frameCount;
            if (frameCount <= 2)
            {
                return;
            }



            FrameTimingManager.CaptureFrameTimings();
            var n = FrameTimingManager.GetLatestTimings(2, frameTimings);
            if(n < 1)
            {
                //return;
            }
            if (uiText != null)
            {
                int width = (int)Mathf.Ceil(ScalableBufferManager.widthScaleFactor * Screen.currentResolution.width);
                int height = (int)Mathf.Ceil(ScalableBufferManager.heightScaleFactor * Screen.currentResolution.height);

                uiText.text = string.Format(
                    "Scale: {0:F3} x {1:F3}\n" +
                    "Resolution: {2} x {3}\n" +
                    "cpuFrameTime: {4:F6}\n" +
                    "gpuFrameTime: {5:F6}\n" +
                    "cpuTimePresentCalled: {6}\n" +
                    "cpuTimeFrameComplete: {7}\n" +
                    "Dynamic Scale: {8:F3} x {9:F3}\n" +
                    "syncInterval: {10}\n" +
                    "GetCpuTimerFrequency: {11}\n" +
                    "GetGpuTimerFrequency: {12}\n" +
                    "GetVSyncsPerSecond: {13}"
                    , 
                    ScalableBufferManager.widthScaleFactor, 
                    ScalableBufferManager.heightScaleFactor,
                    width,
                    height,
                    frameTimings[0].cpuFrameTime,
                    frameTimings[0].gpuFrameTime,
                    frameTimings[0].cpuTimePresentCalled,
                    frameTimings[0].cpuTimeFrameComplete,
                    frameTimings[0].widthScale,
                    frameTimings[0].heightScale,
                    frameTimings[0].syncInterval,
                    FrameTimingManager.GetCpuTimerFrequency(),
                    FrameTimingManager.GetGpuTimerFrequency(),                   
                    FrameTimingManager.GetVSyncsPerSecond()
                    );            
            }
        }
    }
}
