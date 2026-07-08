using System;
using UnityEngine;

namespace ngov3;

public class FPSCounter : MonoBehaviour
{
	[SerializeField]
	private float m_updateInterval = 0.5f;

	private float m_accum;

	private int m_frames;

	private float m_timeleft;

	private float m_fps;

	private void Update()
	{
		m_timeleft -= Time.deltaTime;
		m_accum += Time.timeScale / Time.deltaTime;
		m_frames++;
		if (!(0f < m_timeleft))
		{
			m_fps = m_accum / (float)m_frames;
			m_timeleft = m_updateInterval;
			m_accum = 0f;
			m_frames = 0;
		}
	}

	private void OnGUI()
	{
		GUILayout.Label("FPS: " + m_fps.ToString("f2"), Array.Empty<GUILayoutOption>());
	}
}
