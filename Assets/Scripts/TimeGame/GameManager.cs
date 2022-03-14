// Creator: Josh Jones
// Creation Time: 2022/03/14 10:36 PM
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HealthBar;

namespace GeneralScripts
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] List<BarManager> listOfPlayers = new List<BarManager>();
		[SerializeField] private GameObject winScreen, loseScreen;
		public void RestartScene() => SceneManager.LoadScene("GameOne");

		private void Start()
		{
			winScreen.SetActive(false);
			loseScreen.SetActive(false);
		}

		public void DoAttack(string _decideWhoToDamage)
		{
			BarManager enemy = listOfPlayers[1];
			BarManager player = listOfPlayers[0];

			if(player.CheckDeath) return;
			if(enemy.CheckDeath) return;

			switch(_decideWhoToDamage)
			{
				case "Critical Hit":
					enemy.Damage(20);
					if(enemy.CheckDeath) winScreen.SetActive(true);
					break;
				case "Hit Enemy":
					enemy.Damage(10);
					if(enemy.CheckDeath) winScreen.SetActive(true);
					break;
				case "Draw" :
				break;
				case "Ouch" :
					player.Damage(10);
					if(player.CheckDeath) loseScreen.SetActive(true);
				break;
				case "Critical Damage":
					player.Damage(20);
					if(player.CheckDeath) loseScreen.SetActive(true);
				break;
			}
		}
	}
}