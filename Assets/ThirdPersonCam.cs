using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // rotate orientation based on mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
        orientation.Rotate(Vector3.up, mouseX);
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
        // clamp Y to +/- 70
        mouseY = Mathf.Clamp(mouseY, -70, 70);
        orientation.Rotate(Vector3.left, mouseY);
        //set rotation z to 0
        orientation.rotation = Quaternion.Euler(orientation.rotation.eulerAngles.x, orientation.rotation.eulerAngles.y, 0);
        //Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        //orientation.forward = viewDir.normalized;

        // rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            //rotate only the y axis
            playerObj.rotation = Quaternion.Euler(new Vector3(playerObj.rotation.eulerAngles.x, Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg, playerObj.rotation.eulerAngles.z));
    }
}
