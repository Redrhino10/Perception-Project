using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public enum Direction
    { up, down, left, right }

    public enum Rotation
    { roll, rollinverse, pitch, pitchinverse, yaw, yawinverse }

    private Direction direction;
    public float translationspeed = 3f;
    public float rotationspeed = 0.2f;
    public float mousesensitivity = 1;
    private float rotationY = 0f;

    public GameObject CameraObject;

    public void FollowMouse()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        /*
        CameraObject.transform.RotateAround(CameraObject.transform.position, -Vector3.up, 
            rotateHorizontal * mousesensitivity);

        CameraObject.transform.RotateAround(Vector3.zero, transform.right, 
            rotateVertical * mousesensitivity);
        */

        float rotationX = CameraObject.transform.localEulerAngles.y + rotateHorizontal * mousesensitivity;

        rotationY += rotateVertical * mousesensitivity;
        CameraObject.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    public void Move(Direction direction)
    {
        //string directiontostring = direction.ToString();
        switch (direction)
        {
            case (Direction.down):
                Debug.Log("down");
                CameraObject.transform.Translate(Vector3.down * Time.deltaTime * translationspeed, Space.Self);
                break;
            case (Direction.left):
                Debug.Log("left");
                CameraObject.transform.Translate(Vector3.left * Time.deltaTime * translationspeed, Space.Self);
                break;
            case (Direction.right):
                Debug.Log("right");
                CameraObject.transform.Translate(Vector3.right * Time.deltaTime * translationspeed, Space.Self);
                break;
            case (Direction.up):
                Debug.Log("up");
                CameraObject.transform.Translate(Vector3.up * Time.deltaTime * translationspeed, Space.Self);
                break;
            default:
                Debug.LogWarning("other???");
                break;
        }
    }

    public void Rotate(Rotation rotation)
    {
        switch (rotation)
        {
            case (Rotation.pitch):
                Debug.Log("pitch");
                CameraObject.transform.Rotate(Vector3.left, rotationspeed, Space.World);
                break;
            case (Rotation.pitchinverse):
                Debug.Log("pitchinverse");
                CameraObject.transform.Rotate(Vector3.right, rotationspeed, Space.World);
                break;
            case (Rotation.yaw):
                Debug.Log("yaw");
                //CameraObject.transform.Rotate(Vector3.up, rotationspeed, Space.World);
                CameraObject.transform.RotateAround(CameraObject.transform.position, Vector3.up, rotationspeed);
                //CameraObject.transform.rotation = Quaternion.Euler(0, 0, CameraObject.transform.rotation.eulerAngles.y - rotationspeed);          
                break;
            case (Rotation.yawinverse):
                Debug.Log("yawinverse");
                //CameraObject.transform.Rotate(Vector3.down, rotationspeed, Space.World);
                CameraObject.transform.RotateAround(CameraObject.transform.position, Vector3.down, rotationspeed);
                //CameraObject.transform.rotation = Quaternion.Euler(0, 0, CameraObject.transform.rotation.eulerAngles.y - rotationspeed);
                break;
            case (Rotation.roll):
                Debug.Log("roll");
                CameraObject.transform.Rotate(Vector3.forward, rotationspeed, Space.World);
                break;
            case (Rotation.rollinverse):
                Debug.Log("rollinverse");
                CameraObject.transform.Rotate(Vector3.back, rotationspeed, Space.World);
                break;
            default:
                Debug.LogWarning("other???");
                break;
        }
    }

    public void ZoomScroll(float zoom)
    {
        float minFov = 15f;
        float maxFov = 90f;

        var fov = CameraObject.GetComponent<Camera>().fieldOfView;
        fov += zoom;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        CameraObject.GetComponent<Camera>().fieldOfView = fov;
    }

    public void ZoomSet(float zoom)
    {
        CameraObject.GetComponent<Camera>().fieldOfView = zoom;
    }
}
