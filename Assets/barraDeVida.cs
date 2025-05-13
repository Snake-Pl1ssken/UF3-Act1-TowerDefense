using UnityEngine;
using UnityEngine.UI;

public class barraDeVida : MonoBehaviour
{
    [SerializeField] private Image imagen;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 offset;

    Color _color;

    public void UpdateBarraDeVida(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;

        float percentageValue = currentValue / maxValue * 100;

        ChangeColor(percentageValue);
    }

    private void Start()
    {
        slider = GetComponent<Slider>();

        _color = new Color32(255, 128, 13, 255);
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = _transform.position + offset;
    }

    private void ChangeColor(float percentageOfHitPoints)
    {
        if (percentageOfHitPoints >= 50)
            imagen.color = Color.green;
        else if (percentageOfHitPoints >= 25)
            imagen.color = _color;
        else
            imagen.color = Color.red;
    }
}
