using System.Net.Sockets;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [Header("Connection Settings")]
    public int port = 11611;

    private TcpClient client;

    /// <summary>
    /// Connects to a computer using the given hostname or IP.
    /// Returns true if successful, false otherwise.
    /// </summary>
    public bool ConnectToComputer(string hostnameOrIP)
    {
        try
        {
            client = new TcpClient();
            client.Connect(hostnameOrIP, port);
            Debug.Log("Connected to " + hostnameOrIP);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to connect: " + e.Message);
            return false;
        }
    }

    /// <summary>
    /// Sends a message to the connected computer.
    /// </summary>
    public void SendAppMessage(string message)
    {
        if (client != null && client.Connected)
        {
            try
            {
                var stream = client.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message + "\n");
                stream.Write(data, 0, data.Length);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to send message: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("Not connected. Cannot send message.");
        }
    }

    private void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Close();
        }
    }
}
