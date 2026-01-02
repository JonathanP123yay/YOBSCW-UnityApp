using UnityEngine;

public class HeadsetTracker : MonoBehaviour
{
    public Transform headsetTransform;
    private Vector3 roomOrigin = Vector3.zero;

    void Update()
    {
        Vector3 relativePos = headsetTransform.position - roomOrigin;
        Quaternion rotation = headsetTransform.rotation;

        // Send this to AppManager for network output
        AppManagerData.Instance.UpdateHeadset(relativePos, rotation);
    }
}
