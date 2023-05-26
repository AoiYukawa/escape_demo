using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Assets.Scripts.UI
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField] private Slider _slider;

		public void SetMaxHealth(int  maxHealth)
		{
			_slider.maxValue = maxHealth;
			_slider.value	= maxHealth;
		}

		public void SetHealth(int health)
		{
			_slider.value = health;
		}
	}
}