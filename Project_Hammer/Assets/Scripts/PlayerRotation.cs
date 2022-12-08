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
        float angle;

        Vector2 input = new Vector2(Input.mousePosition.y, Input.mousePosition.x) - new Vector2(Screen.height / 2, Screen.width / 2);
        angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle += 360;

        return angle;
    }
}
