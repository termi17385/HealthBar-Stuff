using System;

using UnityEngine;

namespace HealthBar
{
	[Serializable]
	public class HealthClass
	{
		[SerializeField, Tooltip("Current health of the character, Do not change in inspector (you can if you want but it will be overridden)")] private float health;
		[SerializeField, Tooltip("Used to set the max health of the character, Set the max health to whatever you want")] private int maxHealth;
		/// <summary> Call this to set and or return the current health of
		/// the character (already handled in the Bar manager script) </summary>
		public float CurrentHealth
		{
			get => health;
			set => health = value;
		}
		/// <summary>
		/// returns the max health of the character (Read Only)
		/// </summary>
		public int MaxHealth => maxHealth;
		/// <summary> Sets up the
		/// characters health </summary>
		public void Setup() => health = maxHealth;
	}
}