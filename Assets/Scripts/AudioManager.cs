using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	private Queue<AudioSource> _pool;
	private int _poolSize = 10;
	
	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		
		_pool = new Queue<AudioSource>();
		for (int i = 0; i < _poolSize; i++)
		{
			var s = gameObject.AddComponent<AudioSource>();
			_pool.Enqueue(s);
		}
		
	}

	public void PlayEvent(AudioEvent audioEvent)
	{
		var source = _pool.Dequeue();
		audioEvent.Play(source);
		StartCoroutine(PlayEvent(source));
	}
	
	private IEnumerator PlayEvent(AudioSource source)
	{
		yield return new WaitForSeconds(source.clip.length);
		
		_pool.Enqueue(source);
	}
}