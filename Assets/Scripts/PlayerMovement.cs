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
    InputAction intertaction;
    Vector2 direction;
    [SerializeField] float speed = 5f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    Friend currentFriend;

    // Start is called before the first frame update
    void Awake()
    {
        playerActionMap = primatyActions.FindActionMap("Player");
        YInput = playerActionMap.FindAction("YMove");
        XInput = playerActionMap.FindAction("XMove");
        intertaction = playerActionMap.FindAction("Interaction");

        YInput.performed += ReadYValue;
        XInput.performed += ReadXValue;
        YInput.canceled += ReadYValue;
        XInput.canceled += ReadXValue;
        intertaction.performed += Interact;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    void Move()
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        transform.Translate(Time.deltaTime * speed * direction.normalized);
    }

    void ReadYValue(InputAction.CallbackContext ctx)
    {
        direction.y = ctx.ReadValue<float>();
        animator.SetFloat("YAxis", direction.y);
    }
    void ReadXValue(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>();
        animator.SetFloat("XAxis", Mathf.Abs(direction.x));
    }

    void Interact(InputAction.CallbackContext ctx)
    {
        if (currentFriend == null)
            return;

        if (currentFriend.isTalking)
        {
            return;
        }

        currentFriend.StartSpeech();
    }

    private void OnEnable()
    {
        XInput.Enable();
        YInput.Enable();
        intertaction.Enable();
    }

    private void OnDisable()
    {
        XInput.Disable();
        YInput.Disable();
        intertaction.Disable();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Friend"))
        {
            currentFriend = collision.GetComponent<Friend>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentFriend = null;
    }
}
