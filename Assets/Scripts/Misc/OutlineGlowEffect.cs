using UnityEngine;
using UnityEngine.UI;

public class OutlineGlowEffect : MonoBehaviour
{
    public Outline buttonOutline; // Reference to the Outline component
    public float pulseSpeed = 1f; // Speed of the pulse
    public Color glowColor = Color.white; // Color for the glow effect, settable in the inspector

    private Color originalColor;
    private float pulseTimer = 0f;

    private void Start()
    {
        if (buttonOutline != null)
        {
            originalColor = buttonOutline.effectColor;
        }
    }

    private void Update()
    {
        if (buttonOutline != null)
        {
            // Increase the pulse timer based on the pulse speed
            pulseTimer += Time.deltaTime * pulseSpeed;

            // Calculate the pulsing effect using a sine wave
            float pulse = (Mathf.Sin(pulseTimer) + 1f) / 2f;

            // Lerp between the original color and the glow color based on the pulse value
            buttonOutline.effectColor = Color.Lerp(originalColor, glowColor, pulse);
        }
    }
}