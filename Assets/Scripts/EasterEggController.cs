using UnityEngine;
using UnityEngine.UI;

public class EasterEggController : MonoBehaviour
{
    public GameObject imageToShow; // Reference to the image GameObject to show when the banana icon is clicked

    // Start is called before the first frame update
    public void Start()
    {
        // Hide the image initially
        if (imageToShow != null)
        {
            imageToShow.SetActive(false);
        }
    }

    // Method to handle the onClick event of the banana icon button
    public void ShowEasterEggImage()
    {
        // Check if the image to show is not null
        if (imageToShow != null)
        {
            // Toggle the visibility of the image
            imageToShow.SetActive(!imageToShow.activeSelf);
        }
    }
    public void ShowBananenfrauImage()
    {
        // Check if the image to show is not null
        if (imageToShow != null)
        {
            // Set the image to the "bananenfrau" sprite or texture
            Sprite sprite = Resources.Load<Sprite>("bananenfrau");

            if (sprite != null)
            {
                imageToShow.GetComponent<Image>().sprite = sprite;
                // Show the image
                imageToShow.SetActive(true);
            }
            else
            {
                Debug.LogError("Could not load 'bananenfrau' sprite. Make sure the image is in the 'Resources' folder.");
            }
        }
    }

}
