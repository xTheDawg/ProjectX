using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float sliderValue = slider.value;
        Globals.animationSpeed = sliderValue;
        Globals.actionCompleteDelay = Globals.dayNightSpeed = 1 / sliderValue;
    }
}
