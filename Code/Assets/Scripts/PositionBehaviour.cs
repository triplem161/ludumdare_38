using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PositionBehaviour : MonoBehaviour {

    public GameObject m_planet;
    public float m_radius;
    public float m_angle;

	void Update()
    {
        transform.up = transform.position - m_planet.transform.position;
        transform.position = m_planet.transform.position + m_radius * new Vector3(Mathf.Cos(m_angle), Mathf.Sin(m_angle), 0f);

		if (m_angle > Mathf.PI * 2)
		{
			m_angle -= Mathf.PI * 2;
		}

		if (m_angle < 0)
		{
			m_angle += Mathf.PI * 2;
		}
    }
}
