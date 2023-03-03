using System;
using UnityEngine;

public class ConSwipeTap : MonoBehaviour
{
    private bool isMobile = false;

    private Vector2 startSwipePoint;
    private Vector2 endSwipePoint;

    private float minDragDistance = 10f;

    private Camera cameraMain;

    private const string LINE_NAME = "Line";

    private void Awake()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        isMobile = false;
#else
        isMobile = true;
#endif        

        cameraMain = Camera.main;
    }

    private void Update()
    {
        if (isMobile)
            CheckMobileTouch();
        else
            CheckDeskTouch();
    }

    private void CheckMobileTouch()
    {
        if (Input.touchCount > 0)
        {
            //Touch touch = Input.touches[0];

            //if (touch.phase == TouchPhase.Began)
            //{
            //    startSwipePoint = touch.position;
            //}
            //else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            //{
            //    endSwipePoint = touch.position;
            //    CalculateSwipe();
            //}
            if (Input.GetMouseButtonDown(0))
            {
                startSwipePoint = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endSwipePoint = Input.mousePosition;
                CalculateSwipe();
            }
        }
    }

    private void CheckDeskTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startSwipePoint = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endSwipePoint = Input.mousePosition;
            CalculateSwipe();
        }
    }

    private void CalculateSwipe()
    {
        if (Mathf.Abs(endSwipePoint.x - startSwipePoint.x) > minDragDistance)
        {
            bool right = false;

            if (startSwipePoint.x > endSwipePoint.x)
                right = false;
            else
                right = true;

            ManagerSwipeTap.Instance.DoSwipe(right);
        }
        else
        {
            RaycastHit hit;
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string name = hit.transform.gameObject.name;

                if (name.Substring(0, 4) == LINE_NAME)
                {
                    int numberLine = Convert.ToInt32(name.Substring(4));
                    ManagerSwipeTap.Instance.DoTap(numberLine);
                }
            }
        }
    }
}
