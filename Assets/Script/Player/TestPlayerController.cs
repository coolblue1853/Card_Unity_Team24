using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float deadZone = 0.1f;
    VirtualJoystick joystick;

    private void Start()
    {
        joystick = VirtualJoystick.instance.GetComponent<VirtualJoystick>();
    }

    void Update()
    {
        Vector2 input = new Vector2(joystick.horizontal, joystick.vertical);

        // magnitude ���� ��� (0 ~ 1), �ִ밪�� 1�� �����Ѵ�.
        float magnitude = Mathf.Min(input.magnitude / joystick.stickRange, 1f);

        // ������ ó��
        if (magnitude < deadZone)
            magnitude = 0f;

        // ����� ũ�� ����
        Vector2 ratioInput = input.normalized * magnitude;

        // �̵�
        transform.position += (Vector3)(ratioInput * speed * Time.deltaTime);
    }
}
