using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ngov3;

public class WebCamManager : SingletonMonoBehaviour<WebCamManager>
{
	public BehaviorSubject<KeyValuePair<string, int>> OnAnimOneShot = new BehaviorSubject<KeyValuePair<string, int>>(new KeyValuePair<string, int>("stream_ame_idle", 1000));

	public Subject<string> _currentAnim = new Subject<string>();

	public ReactiveProperty<bool> hidegirl = new ReactiveProperty<bool>(false);

	public string baseAnim;

	private string[] normal = new string[9] { "stream_ame_handspinner1", "stream_ame_headphone", "stream_ame_idle", "stream_ame_nail", "stream_ame_selfie", "stream_ame_sleep", "stream_ame_voice_training", "stream_ame_idle_normal_a", "stream_ame_idle_happy_a" };

	private string[] normalStress = new string[2] { "stream_ame_idle_iraira_a", "stream_ame_idle_anxiety_a" };

	private string[] yami4 = new string[2] { "stream_ame_idle_normal_b", "stream_ame_idle_happy_b" };

	private string[] yami4Stress = new string[2] { "stream_ame_idle_iraira_b", "stream_ame_idle_anxiety_b" };

	private string[] yami5 = new string[2] { "stream_ame_idle_normal_c", "stream_ame_idle_happy_c" };

	private string[] yami5Stress = new string[2] { "stream_ame_idle_iraira_c", "stream_ame_idle_anxiety_c" };

	private string[] horror = new string[2] { "stream_ame_idle_iraira_c", "stream_ame_idle_anxiety_c" };

	private string[] crazy = new string[1] { "stream_ame_craziness" };

	private string[] suki4 = new string[2] { "stream_ame_idle_normal_e", "stream_ame_idle_happy_e" };

	private string[] suki4Stress = new string[2] { "stream_ame_idle_iraira_e", "stream_ame_idle_anxiety_e" };

	private string[] suki5 = new string[2] { "stream_ame_idle_normal_f", "stream_ame_idle_happy_f" };

	private string[] suki5Stress = new string[2] { "stream_ame_idle_iraira_f", "stream_ame_idle_anxiety_f" };

	private string[] yamisuki5 = new string[2] { "stream_ame_idle_normal_g", "stream_ame_idle_happy_g" };

	private string[] yamisuki5Stress = new string[2] { "stream_ame_idle_iraira_g", "stream_ame_idle_anxiety_g" };

	private void Start()
	{
		RandomizeAmeAnimation();
	}

	public string RandomizeAmeAnimation()
	{
		string[] statusFace = GetStatusFace();
		string text = (baseAnim = statusFace[Random.Range(0, statusFace.Length)]);
		_currentAnim.OnNext(text);
		return text;
	}

	private string[] GetStatusFace()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror)
		{
			return horror;
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status2 >= 80 && status3 >= 80)
		{
			if (status >= 60)
			{
				return yamisuki5Stress;
			}
			return yamisuki5;
		}
		if (status3 >= status2)
		{
			if (status3 >= 80)
			{
				if (status >= 60)
				{
					return suki5Stress;
				}
				return suki5;
			}
			if (status3 >= 60)
			{
				if (status >= 60)
				{
					return suki4Stress;
				}
				return suki4;
			}
		}
		else
		{
			if (status2 >= 80)
			{
				if (status >= 60)
				{
					return yami5Stress;
				}
				return yami5;
			}
			if (status2 >= 60)
			{
				if (status >= 60)
				{
					return yami4Stress;
				}
				return yami4;
			}
		}
		if (status >= 60)
		{
			return normalStress;
		}
		return normal;
	}

	public void PlayCurrentAnim()
	{
		PlayAnim(baseAnim);
	}

	public void PlayAnim(string name)
	{
		_currentAnim.OnNext(name);
	}

	public void happy()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status >= 80 && status2 >= 80)
		{
			_currentAnim.OnNext("stream_ame_idle_happy_g");
			return;
		}
		if (status2 >= status)
		{
			if (status2 >= 80)
			{
				_currentAnim.OnNext("stream_ame_idle_happy_f");
				return;
			}
			if (status2 >= 60)
			{
				_currentAnim.OnNext("stream_ame_idle_happy_e");
				return;
			}
		}
		else
		{
			if (status >= 80)
			{
				_currentAnim.OnNext("stream_ame_idle_happy_c");
				return;
			}
			if (status >= 60)
			{
				_currentAnim.OnNext("stream_ame_idle_happy_b");
				return;
			}
		}
		_currentAnim.OnNext("stream_ame_smile");
	}

	public void WatchSp()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror)
		{
			_currentAnim.OnNext("stream_ame_talk_c");
			return;
		}
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status >= 80 && status2 >= 80)
		{
			_currentAnim.OnNext("stream_ame_talk_g");
			return;
		}
		if (status2 >= status)
		{
			if (status2 >= 80)
			{
				_currentAnim.OnNext("stream_ame_talk_f");
				return;
			}
			if (status2 >= 60)
			{
				_currentAnim.OnNext("stream_ame_talk_e");
				return;
			}
		}
		else
		{
			if (status >= 80)
			{
				_currentAnim.OnNext("stream_ame_talk_c");
				return;
			}
			if (status >= 60)
			{
				_currentAnim.OnNext("stream_ame_talk_b");
				return;
			}
		}
		_currentAnim.OnNext("stream_ame_talk_a");
	}

	public void Movie()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status >= 80 && status2 >= 80)
		{
			_currentAnim.OnNext("stream_ame_movie_g");
			return;
		}
		if (status2 >= status)
		{
			if (status2 >= 80)
			{
				_currentAnim.OnNext("stream_ame_movie_f");
				return;
			}
			if (status2 >= 60)
			{
				_currentAnim.OnNext("stream_ame_movie_e");
				return;
			}
		}
		else
		{
			if (status >= 80)
			{
				_currentAnim.OnNext("stream_ame_movie_c");
				return;
			}
			if (status >= 60)
			{
				_currentAnim.OnNext("stream_ame_movie_b");
				return;
			}
		}
		_currentAnim.OnNext("stream_ame_movie");
	}

	public void Gaming()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status >= 80 && status2 >= 80)
		{
			_currentAnim.OnNext("stream_ame_game_g");
			return;
		}
		if (status2 >= status)
		{
			if (status2 >= 80)
			{
				_currentAnim.OnNext("stream_ame_game_f");
				return;
			}
			if (status2 >= 60)
			{
				_currentAnim.OnNext("stream_ame_game_e");
				return;
			}
		}
		else
		{
			if (status >= 80)
			{
				_currentAnim.OnNext("stream_ame_game_c");
				return;
			}
			if (status >= 60)
			{
				_currentAnim.OnNext("stream_ame_game_b");
				return;
			}
		}
		_currentAnim.OnNext("stream_ame_game_a");
	}

	public void GoOut()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		if (status >= 80 && status2 >= 80)
		{
			_currentAnim.OnNext("stream_ame_out_g");
			return;
		}
		if (status2 >= status)
		{
			if (status2 >= 80)
			{
				_currentAnim.OnNext("stream_ame_out_f");
				return;
			}
			if (status2 >= 60)
			{
				_currentAnim.OnNext("stream_ame_out_e");
				return;
			}
		}
		else
		{
			if (status >= 80)
			{
				_currentAnim.OnNext("stream_ame_out_c");
				return;
			}
			if (status >= 60)
			{
				_currentAnim.OnNext("stream_ame_out_b");
				return;
			}
		}
		_currentAnim.OnNext("stream_ame_out_a");
	}

	public void SetBaseAnim(string name)
	{
		baseAnim = name;
		_currentAnim.OnNext(name);
	}

	public void HideGirl(bool onoff = false)
	{
		hidegirl.Value = !onoff;
	}

	public void ResetAnim()
	{
		_currentAnim.OnNext(baseAnim);
	}
}
