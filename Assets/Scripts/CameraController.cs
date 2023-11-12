using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -10); // Offset values for X, Y, and Z axes

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
    
            return;
        }

        transform.position = new Vector3(0, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
    }
}
