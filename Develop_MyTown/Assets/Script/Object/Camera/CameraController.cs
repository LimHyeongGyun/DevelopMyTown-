using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static StateManager;

public class CameraController : MonoBehaviour, IMouseInput
{
    private InputManager inputManager;

    public MouseWheelValue mouseWheelValue;

    public Transform cameraObj; //ī�޶� ������Ʈ
    public Transform characterBody; //�÷��̾� ��

    //ī�޶� offset
    [SerializeField]
    private float camera_dist = 0f;
    private float camera_width = -5.5f;
    private float camera_height = 8f;

    private const float cameraRotateX = 35;

    Vector3 offset;

    //ī�޶� Zoom In/Out
    public const float toggleSpeed = 200;
    public const float minToggleValue = 5;
    public const float maxToggleValue = 90;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void Start()
    {
        CameraRotation();
        offset = cameraObj.position - characterBody.position;

        inputManager.mouseAction += InputMouseValue;
    }
    void LateUpdate()
    {
        CameraPosition();
        ZoomInOut();
    }

    private void CameraPosition()
    {
        cameraObj.localPosition = characterBody.position + offset; //�÷��̾�� �������� ����
    }
    private void CameraRotation()
    {
        transform.rotation = Quaternion.Euler(cameraRotateX, 0, 0);
    }
    
    //���콺 �Է°� �ޱ�
    public void InputMouseValue(MouseButton mouseBtn, InputMouseType inputType)
    {
        if (inputType == InputMouseType.None)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                mouseWheelValue = MouseWheelValue.None;
            }
        }
        if (inputType == InputMouseType.Up)
        {

        }
        if (inputType == InputMouseType.Down)
        {

        }
        if (inputType == InputMouseType.Drag)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                Vector2 wheelvalue = Input.mouseScrollDelta;
                if (wheelvalue.y > 0)
                {
                    mouseWheelValue = MouseWheelValue.Up;
                }
                if (wheelvalue.y < 0)
                {
                    mouseWheelValue = MouseWheelValue.Down;
                }
            }
        }
    }

    private void ZoomInOut()
    {
        //ī�޶� ����/�ƿ�
        if (mouseWheelValue == MouseWheelValue.Up)
        {
            var toggleValue = cameraObj.GetComponent<Camera>().fieldOfView;
            if (minToggleValue < toggleValue)
            {
                toggleValue -= toggleSpeed * Time.deltaTime;
                if (toggleValue < minToggleValue)
                {
                    toggleValue = minToggleValue;
                }
                cameraObj.GetComponent<Camera>().fieldOfView = toggleValue;
            }
        }
        if (mouseWheelValue == MouseWheelValue.Down)
        {
            var toggleValue = cameraObj.GetComponent<Camera>().fieldOfView;
            if (toggleValue < maxToggleValue)
            {
                toggleValue += toggleSpeed * Time.deltaTime;
                if (toggleValue > maxToggleValue)
                {
                    toggleValue = maxToggleValue;
                }
                cameraObj.GetComponent<Camera>().fieldOfView = toggleValue;
            }
        }
    }
    //�� ���� �������·� ����
    public void ReturnToggleValue()
    {
        cameraObj.GetComponent<Camera>().fieldOfView = 60f;
    }
}
