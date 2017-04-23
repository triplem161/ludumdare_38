using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DudeManager : MonoBehaviour {

    public List<GameObject> m_dudes;
    int m_selectedDude = 0;

	void Start ()
    {
        selectDude(m_selectedDude);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectDude(m_selectedDude + 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectDude(m_selectedDude - 1);
        }
    }

    void selectDude(int p_index)
    {
        if (p_index < 0)
            p_index += m_dudes.Count;
        GameObject oldDude = m_dudes[m_selectedDude];
        m_selectedDude = p_index % m_dudes.Count;
        GameObject dude = m_dudes[m_selectedDude];

        oldDude.GetComponent<SpriteRenderer>().color = Color.white;
        dude.GetComponent<SpriteRenderer>().color = Color.red;

    }
}
