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
        GameObject currentDude = m_dudes[m_selectedDude];
        int nextDudeIndex = Mathf.Clamp(p_index, 0, m_dudes.Count - 1);
        GameObject nextDude = m_dudes[nextDudeIndex];

        if (currentDude.GetComponent<MovementBehaviour>().isLinkToDude(nextDude))
        {
            m_selectedDude = nextDudeIndex;
            currentDude.GetComponent<SpriteRenderer>().color = Color.white;
            nextDude.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
