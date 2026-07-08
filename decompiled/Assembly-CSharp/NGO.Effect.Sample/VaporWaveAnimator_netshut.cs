using NGO.Effect.Runtime.Volume;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace NGO.Effect.Sample;

[RequireComponent(typeof(Volume))]
public sealed class VaporWaveAnimator_netshut : MonoBehaviour
{
	private SidePanelStatue _statue;

	private SidePanelGridTerrain _gridTerrain;

	private SidePanelWave _sidePanelWave;

	private SidePanelHeart _sidePanelHeart;

	private SidePanelStream _sidePanelStream;

	private Volume _volume;

	private void Start()
	{
		_volume = GetComponent<Volume>();
		_volume.profile.TryGet<SidePanelStatue>(out _statue);
		_volume.profile.TryGet<SidePanelGridTerrain>(out _gridTerrain);
		_volume.profile.TryGet<SidePanelWave>(out _sidePanelWave);
		_volume.profile.TryGet<SidePanelHeart>(out _sidePanelHeart);
		_volume.profile.TryGet<SidePanelStream>(out _sidePanelStream);
	}

	private void Update()
	{
		float num = Time.time * 1.4723927f % 1f;
		float num2 = math.floor(Time.time * 1.4723927f);
		_gridTerrain.speed.value = math.lerp(4f, 1f, math.saturate(num * 2f));
		_gridTerrain.terrainScale.value = math.lerp(1.6f, 0.6f, math.saturate(num * 2f));
		_gridTerrain.twist.value = math.lerp(1.6f, 1f, math.saturate(num * 2f));
		_gridTerrain.sphereColor.value = ToColor(math.lerp(math.float3(10f, 0f, 4f), math.float3(0f, 4f, 4f), math.saturate(num * 2f)));
		_statue.scale.value = math.lerp(1f, 0.8f, math.saturate(num * 2f));
		_statue.voxelSize.value = math.lerp(0.3f, 0.04f, math.saturate(num * 2f));
		_statue.speed.value = math.lerp(4f, 0.5f, math.saturate(num * 2f));
		_sidePanelWave.time.value = math.lerp(0.3f, 0.8f, math.pow(num, 0.5f));
		_sidePanelWave.color.value = Color.HSVToRGB(num2 * 0.3f % 1f, 1f, 1f);
		_sidePanelHeart.time.value = math.lerp(0.3f, 1.5f, num);
		_sidePanelStream.intensity.value = math.lerp(1f, 0f, math.saturate(num * 2f));
		_volume.weight = 1f;
	}

	private Color ToColor(float3 value)
	{
		return new Color(value.x, value.y, value.z);
	}
}
