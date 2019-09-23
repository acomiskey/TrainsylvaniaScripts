using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEyesight : MonoBehaviour
{
    public float maxAngle = 60F;
    bool menuopen = false;

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 3.0f;
    public float smoothing = 2.0f;

    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!menuopen)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            menuopen = !menuopen;
        }

        if (!menuopen)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -maxAngle, maxAngle);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
    }
}
