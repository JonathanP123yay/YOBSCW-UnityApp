using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public InputField inputField_HostnameOrIP;
    public Button button_Connect;
    public Text text_Status;
    public Dropdown dropdown_ConnectionType; // e.g., 0 = Hostname, 1 = IP

    [Header("App Manager Reference")]
    public AppManager appManager;

    void Start()
    {
        // Initialize UI
        if (dropdown_ConnectionType != null)
        {
            dropdown_ConnectionType.onValueChanged.AddListener(OnDropdownChanged);
        }

        if (button_Connect != null)
        {
            button_Connect.onClick.AddListener(OnConnectButtonPressed);
        }

        UpdateStatus("Ready");
    }

    void OnDropdownChanged(int index)
    {
        if (index == 0)
        {
            inputField_HostnameOrIP.placeholder.GetComponent<Text>().text = "Enter Hostname";
        }
        else
        {
            inputField_HostnameOrIP.placeholder.GetComponent<Text>().text = "Enter IP Address";
        }
    }

    void OnConnectButtonPressed()
    {
        string target = inputField_HostnameOrIP.text.Trim();
        if (string.IsNullOrEmpty(target))
        {
            UpdateStatus("Please enter a hostname or IP");
            return;
        }

        if (appManager != null)
        {
            bool success = appManager.ConnectToComputer(target);
            if (success)
                UpdateStatus("Connected to " + target);
            else
                UpdateStatus("Failed to connect to " + target);
        }
        else
        {
            UpdateStatus("AppManager not assigned");
        }
    }

    public void UpdateStatus(string message)
    {
        if (text_Status != null)
        {
            text_Status.text = message;
        }
    }
}
