using System;
using UnityEngine;

namespace ngov3;

[Serializable]
public class Sound
{
	public string Id;

	public MusicTitle Music;

	public AudioClip Clip;

	public string Category;

	public VolumeType VolumeType;
}
