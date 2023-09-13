
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SliderCopy : UdonSharpBehaviour
{
    [Header("Slider Reference")]
    [SerializeField]
    public Slider sliderA;
    public Slider sliderB;

    void Start()
    {
        
    }

    public void SliderValuesA()
    {
        sliderB.value = sliderA.value;
    }

    public void SliderValuesB()
    {
        sliderA.value = sliderB.value;
    }
}
