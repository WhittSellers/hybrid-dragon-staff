using UnityEngine;
using UnityEngine.InputSystem;



sealed class RotateByInputValue : MonoBehaviour
{
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    
    [SerializeField] Transform _transform = null;
    [SerializeField] InputAction _action = null;

    private Vector3 rotVec = Vector3.zero;

    void OnEnable()
    {
        _action.performed += OnPerformed;
        _action.Enable();
    }

    void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action.Disable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
      => CustomRotate(ctx);
    

    void CustomRotate(InputAction.CallbackContext ctx)
    {
        if(rotateX)
        {
            rotVec = new Vector3(1.0f * ctx.ReadValue<float>(), 0.0f, 0.0f);
        }

        if(rotateY)
        {
            rotVec = new Vector3(0.0f, 1.0f * ctx.ReadValue<float>(), 0.0f);
        }

        if(rotateZ)
        {
            rotVec = new Vector3(0.0f, 0.0f, 1.0f * ctx.ReadValue<float>());
        }
    }

    void Update()
    {
        _transform.Rotate(rotVec);
    }
}