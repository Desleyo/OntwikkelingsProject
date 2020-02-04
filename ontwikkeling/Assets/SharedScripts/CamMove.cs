using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    float currentY;
    float currentX;
    GameObject player;

    public float sens = 3;
    public float maxY = 45f, minY = -55f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        currentX -= Input.GetAxis("Mouse Y") * sens;
        currentY += Input.GetAxis("Mouse X") * sens;

        currentX = Mathf.Clamp(currentX, minY, maxY);
        Quaternion rot = Quaternion.Euler(currentX, currentY, 0);
        Quaternion rotPlayer = Quaternion.Euler(0, currentY, 0);
        Camera.main.transform.rotation = rot;
        player.transform.localRotation = rotPlayer;
    }
}
