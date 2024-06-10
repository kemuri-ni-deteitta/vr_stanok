
using UnityEngine;
using TMPro;

public class TextMeshProCollisionCounter : MonoBehaviour
{
    // Reference to the TextMeshPro component
    public TextMeshPro textMeshPro;
    private int counter = 0;

    private void Start()
    {
        // Initialize the text with the counter value
        UpdateText();
    }



    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other object
        if (collision.gameObject.CompareTag("OtherObjectTag"))
        {
            // Increment the counter
            counter++;

            // Update the TextMeshPro text with the new counter value
            UpdateText();

            // Print to the console
            Debug.Log("Collision occurred with object tagged as OtherObjectTag");
        }
    }

    private void UpdateText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = "Count: " + counter;
        }
    }
}
