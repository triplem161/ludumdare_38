using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowDude : MonoBehaviour
{

    public GameObject m_planet;
    public GameObject m_dude;
    public float m_radius;
    public float m_speed;
    public float m_angle;

    void Update()
    {
        transform.position = m_planet.transform.position + m_radius * new Vector3(Mathf.Cos(m_angle), Mathf.Sin(m_angle), 0f);
        if (Input.GetKey(KeyCode.A))
        {
            m_angle += Time.deltaTime * m_speed * m_dude.GetComponent<MovementBehaviour>().m_leftSpeed;
            if (m_angle > Mathf.PI * 2)
            {
                m_angle -= Mathf.PI * 2;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_angle -= Time.deltaTime * m_speed * m_dude.GetComponent<MovementBehaviour>().m_rightSpeed;
            if (m_angle < 0)
            {
                m_angle += Mathf.PI * 2;
            }
        }
    }
}
