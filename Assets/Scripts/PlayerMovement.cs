using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionAsset primatyActions;
    InputActionMap playerActionMap;
    InputAction YInput;
    InputAction XInput;
    Vector2 direction;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        playerActionMap = primatyActions.FindActionMap("Player");
        YInput = playerActionMap.FindAction("YMove");
        XInput = playerActionMap.FindAction("XMove");

        YInput.performed += ReadYValue;
        XInput.performed += ReadXValue; 
        YInput.canceled += ReadYValue;
        XInput.canceled += ReadXValue;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(direction);

        Move();
    }

    void Move()
    {
        transform.Translate(Time.deltaTime * speed * direction.normalized);
    }

    void ReadYValue(InputAction.CallbackContext ctx)
    {
        direction.y = ctx.ReadValue<float>();
    }
    void ReadXValue(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        XInput.Enable();
        YInput.Enable();
    }

    private void OnDisable()
    {
        XInput.Disable();
        YInput.Disable();
    }

}
