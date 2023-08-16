using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //Make sure there is a BoxCollider component attached to your GameObject
    BoxCollider m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;
    public Slider m_SliderX, m_SliderY, m_SliderZ;


    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        //These are the starting sizes for the Collider component
        m_ScaleX = 1.0f;
        m_ScaleY = 1.0f;
        m_ScaleZ = 1.0f;

        //Set all the sliders max values to 20 so the size values don't go above 20
        m_SliderX.maxValue = 20;
        m_SliderY.maxValue = 20;
        m_SliderZ.maxValue = 20;

        //Set all the sliders min values to 1 so the size don't go below 1
        m_SliderX.minValue = 1;
        m_SliderY.minValue = 1;
        m_SliderZ.minValue = 1;
    }

    void Update()
    {
        m_ScaleX = m_SliderX.value;
        m_ScaleY = m_SliderY.value;
        m_ScaleZ = m_SliderZ.value;

        m_Collider.size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);
        Debug.Log("Current BoxCollider Size : " + m_Collider.size);
    }
}