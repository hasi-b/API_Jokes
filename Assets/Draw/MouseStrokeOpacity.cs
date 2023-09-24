using UnityEngine;
using UnityEngine.UI;

public class MouseStrokeOpacity : MonoBehaviour
{
    public Image imageToModify;
    public float transitionDuration = 0.5f;
    public float detectionThreshold = 10f; // Adjust this value for sensitivity

    private float screenThird;
    private bool isMousePressed;
    private bool isIncreasingOpacity = true; // Flag to control opacity increase
    private Vector3 lastMousePosition;
    private int brushStrokeCount = 0;
    private float targetOpacity = 1.0f; // Target opacity to reach

    private void Start()
    {
        // Calculate the width of each third of the screen
        screenThird = Screen.width / 3.0f;
    }

    private void Update()
    {
        // Check if the mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // Get the current mouse position
            Vector3 currentMousePosition = Input.mousePosition;

            // Calculate the horizontal movement
            float horizontalMovement = currentMousePosition.x - lastMousePosition.x;

            // Check if the mouse moved from left to right and exceeds the detection threshold
            if (isMousePressed && Mathf.Abs(horizontalMovement) > detectionThreshold)
            {
                // Calculate the opacity value based on mouse position
                float opacity = Mathf.InverseLerp(screenThird * 2, Screen.width, currentMousePosition.x);

                // Ensure opacity only increases and never decreases
                if (isIncreasingOpacity || opacity > imageToModify.color.a)
                {
                    // Update the opacity value
                    float currentOpacity = imageToModify.color.a;

                    // Smoothly transition the opacity value
                    float lerpTime = transitionDuration > 0 ? Time.deltaTime / transitionDuration : 1.0f;
                    float newOpacity = Mathf.Lerp(currentOpacity, targetOpacity, lerpTime);

                    // Set the new opacity value to the image
                    Color newColor = imageToModify.color;
                    newColor.a = newOpacity;
                    imageToModify.color = newColor;

                    // Check if opacity is increasing and set the flag accordingly
                    isIncreasingOpacity = opacity >= currentOpacity;

                    // Check if opacity has reached or exceeded the target
                    if (newOpacity >= targetOpacity)
                    {
                        brushStrokeCount++;

                        // If two brush strokes have occurred, stop increasing opacity
                        if (brushStrokeCount >= 2)
                        {
                            isMousePressed = false;
                            brushStrokeCount = 0;
                        }
                    }
                }
            }
            else
            {
                isMousePressed = true; // Start tracking when the mouse button is pressed
            }

            // Update the lastMousePosition
            lastMousePosition = currentMousePosition;
        }
        else
        {
            isMousePressed = false; // Reset tracking when the mouse button is released
        }
    }
}
