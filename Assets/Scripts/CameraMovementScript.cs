using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public enum Direction
    { up, down, left, right}

    private Direction direction;
    public float speed = 3;

    public GameObject CameraObject;

    public void Move(Direction direction)
    {
        string directiontostring = direction.ToString();
        switch(direction)
        {
            case (Direction.down):
                Debug.Log("down");
                CameraObject.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                break;
            case (Direction.left):
                Debug.Log("left");
                CameraObject.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
                break;
            case (Direction.right):
                Debug.Log("right");
                CameraObject.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
                break;
            case (Direction.up):
                Debug.Log("up");
                CameraObject.transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
                break;
            default:
                Debug.LogWarning("other???");
                break;
        }
    }
}
