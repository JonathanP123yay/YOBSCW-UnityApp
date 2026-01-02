using UnityEngine;

public class AppManagerData : MonoBehaviour
{
    public static AppManagerData Instance;

    public Vector3 headsetPos;
    public Quaternion headsetRot;
    public Vector3 leftCtrlPos;
    public Vector3 rightCtrlPos;

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHeadset(Vector3 pos, Quaternion rot)
    {
        headsetPos = pos;
        headsetRot = rot;
    }

    public void UpdateControllers(Vector3 left, Vector3 right)
    {
        leftCtrlPos = left;
        rightCtrlPos = right;
    }
}
