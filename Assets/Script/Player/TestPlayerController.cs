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

        // magnitude 비율 계산 (0 ~ 1), 최대값은 1로 제한한다.
        float magnitude = Mathf.Min(input.magnitude / joystick.stickRange, 1f);

        // 데드존 처리
        if (magnitude < deadZone)
            magnitude = 0f;

        // 방향과 크기 결합
        Vector2 ratioInput = input.normalized * magnitude;

        // 이동
        transform.position += (Vector3)(ratioInput * speed * Time.deltaTime);
    }
}
