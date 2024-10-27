using UnityEngine;
using TMPro;

public class FlashingText : MonoBehaviour
{
    public TextMeshProUGUI text; // Reference to the Text component
    public float flashSpeed = 1f; // Speed of the flash

    private float flashTimer = 0f;

    private void Start()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (text != null)
        {
            // Increase the flash timer based on the flash speed
            flashTimer += Time.deltaTime * flashSpeed;

            // Calculate the flashing effect using a sine wave
            float flash = (Mathf.Sin(flashTimer) + 1f) / 2f;

            // Set the alpha of the text color based on the flash value
            Color newColor = text.color;
            newColor.a = flash;
            text.color = newColor;
        }
    }
}