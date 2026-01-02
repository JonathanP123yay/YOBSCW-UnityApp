using UnityEngine;

public class ControllerTracker : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    void Update()
    {
        AppManagerData.Instance.UpdateControllers(leftController.position, rightController.position);
    }
}
