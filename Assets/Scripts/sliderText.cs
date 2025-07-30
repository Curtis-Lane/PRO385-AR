using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderText : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public void setText()
    {
        text.text = slider.value.ToString();
    }
}
