using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out depthOfField);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Press B to blur
        {
            depthOfField.focusDistance.value = 0.1f; // Increase blur
        }
        if (Input.GetKeyDown(KeyCode.N)) // Press N to remove blur
        {
            depthOfField.focusDistance.value = 10f; // Remove blur
        }
    }
}
