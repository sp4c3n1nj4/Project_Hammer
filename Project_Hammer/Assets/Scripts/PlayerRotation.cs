using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    public GameObject model;
    public CharacterController player;

    void Update()
    {
        TurnCharacter();
    }

    private void TurnCharacter()
    {
        float rotation = MouseRotation();

        //slowly turn character towards intended rotation
        float lerpedRotation = Mathf.LerpAngle(rotation, player.transform.rotation.eulerAngles.y, 0.5f);

        player.transform.rotation = Quaternion.AngleAxis(lerpedRotation, Vector3.up);
    }

    private float MouseRotation()
    {
        var vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10f);
        var point = new Vector3(-_camera.ScreenToWorldPoint(vector).x, 0, -_camera.ScreenToWorldPoint(vector).z);
        print(point);
        var angle = Mathf.Atan2(point.x, point.z) * Mathf.Rad2Deg;
        return angle;
    }

    private void OnDrawGizmos()
    {
        var vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10f);
        var point = new Vector3(-_camera.ScreenToWorldPoint(vector).x, 0, -_camera.ScreenToWorldPoint(vector).z);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(point, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, point);
    }
}
