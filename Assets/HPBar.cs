using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Health playerHP;
    public Slider slider;

    private void Start()
    {
        slider.value = 0;
    }

    private void Update()
    {
        slider.value = (100f - (playerHP.Hp))/100f;
        Debug.Log("slider updated");
    }
}
