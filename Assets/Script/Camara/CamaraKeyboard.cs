using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraKeyboard : MonoBehaviour
{
    [SerializeField] private float m_fSpeed = 10.0f;

    void Update()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * m_fSpeed * fHorizontal, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * m_fSpeed * fVertical, Space.World);
    }
}
