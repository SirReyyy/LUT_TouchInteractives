using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
    public int playerIndex = 0;

    // [Tooltip("UI-Text to display gesture-listener messages and gesture information.")]
    // public UnityEngine.UI.Text gestureInfo;

    // singleton instance of the class
    private static PoleGestureListener instance = null;

    // internal variables to track if progress message has been displayed
    private bool progressDisplayed;
    private float progressGestureTime;

    // whether the needed gesture has been detected or not
    private bool swipeLeft = false;
    private bool swipeRight = false;
    // private bool swipeUp = false;


    public static PoleGestureListener Instance
    {
        get
        {
            return instance;
        }
    }


    public bool IsSwipeLeft()
    {
        if (swipeLeft)
        {
            swipeLeft = false;
            return true;
        }

        return false;
    }


    public bool IsSwipeRight()
    {
        if (swipeRight)
        {
            swipeRight = false;
            return true;
        }

        return false;
    }

    /*
    public bool IsSwipeUp() {
        if (swipeUp) {
            swipeUp = false;
            return true;
        }

        return false;
    }
    */


    public void UserDetected(long userId, int userIndex)
    {
        // the gestures are allowed for the primary user only
        KinectManager manager = KinectManager.Instance;
        if (!manager || (userIndex != playerIndex))
            return;

        // detect these user specific gestures
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
        // manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);

        /*
        if (gestureInfo != null) {
            gestureInfo.text = "Swipe left, right or up to change the slides.";
        }
        */
    }


    public void UserLost(long userId, int userIndex)
    {
        // the gestures are allowed for the primary user only
        if (userIndex != playerIndex)
            return;

        /*
        if (gestureInfo != null) {
            gestureInfo.text = string.Empty;
        }
        */

    }


    public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  float progress, KinectInterop.JointType joint, Vector3 screenPos)
    {
        // the gestures are allowed for the primary user only
        if (userIndex != playerIndex)
            return;

        if ((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
        {
            /*
            if (gestureInfo != null)
            {
                string sGestureText = string.Format("{0} - {1:F0}%", gesture, screenPos.z * 100f);
                gestureInfo.text = sGestureText;

                progressDisplayed = true;
                progressGestureTime = Time.realtimeSinceStartup;
            }
            */
        }
        else if ((gesture == KinectGestures.Gestures.Wheel || gesture == KinectGestures.Gestures.LeanLeft ||
                 gesture == KinectGestures.Gestures.LeanRight) && progress > 0.5f)
        {
            /*
            if (gestureInfo != null)
            {
                string sGestureText = string.Format("{0} - {1:F0} degrees", gesture, screenPos.z);
                gestureInfo.text = sGestureText;

                progressDisplayed = true;
                progressGestureTime = Time.realtimeSinceStartup;
            }
            */
        }
        else if (gesture == KinectGestures.Gestures.Run && progress > 0.5f)
        {
            /*
            if (gestureInfo != null)
            {
                string sGestureText = string.Format("{0} - progress: {1:F0}%", gesture, progress * 100);
                gestureInfo.text = sGestureText;

                progressDisplayed = true;
                progressGestureTime = Time.realtimeSinceStartup;
            }
            */
        }
    }


    public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectInterop.JointType joint, Vector3 screenPos)
    {
        // the gestures are allowed for the primary user only
        if (userIndex != playerIndex)
            return false;
        /*
        if (gestureInfo != null)
        {
            string sGestureText = gesture + " detected";
            gestureInfo.text = sGestureText;
        }
        */

        if (gesture == KinectGestures.Gestures.SwipeLeft)
            swipeLeft = true;
        else if (gesture == KinectGestures.Gestures.SwipeRight)
            swipeRight = true;
        // else if (gesture == KinectGestures.Gestures.SwipeUp)
        //     swipeUp = true;

        return true;
    }


    public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectInterop.JointType joint)
    {
        // the gestures are allowed for the primary user only
        if (userIndex != playerIndex)
            return false;

        if (progressDisplayed)
        {
            progressDisplayed = false;
            /*
            if (gestureInfo != null)
            {
                gestureInfo.text = String.Empty;
            }
            */
        }

        return true;
    }


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (progressDisplayed && ((Time.realtimeSinceStartup - progressGestureTime) > 2f))
        {
            progressDisplayed = false;
            // gestureInfo.text = String.Empty;

            Debug.Log("Forced progress to end.");
        }
    }

} //-- class end


/*
Project: 
Made by: 
*/

