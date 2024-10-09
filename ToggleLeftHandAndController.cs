using UnityEngine;

public class ToggleLeftHandAndController : MonoBehaviour
{
    public GameObject leftController;
    public GameObject weartLeftHand;

    private void Start()
    {
        // Ensure both objects are initially deactivated
        if (leftController != null)
        {
            leftController.SetActive(false);
            Debug.Log("LeftController is initially deactivated.");
        }

        if (weartLeftHand != null)
        {
            weartLeftHand.SetActive(false);
            Debug.Log("WEARTLeftHand is initially deactivated.");
        }
    }

    // Public method to toggle both objects
    public void ToggleObjects()
    {
        if (leftController != null && weartLeftHand != null)
        {
            bool newState = !leftController.activeSelf;
            leftController.SetActive(newState);
            weartLeftHand.SetActive(newState);
            Debug.Log($"LeftController and WEARTLeftHand active: {newState}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the right hand controller
        if (other.CompareTag("RightHand"))
        {
            ToggleObjects();
            Debug.Log("Switch activated by RightHand.");
        }
    }
}
