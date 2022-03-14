using GeneralScripts;

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

using static UnityEngine.Mathf;

public class BarManager : MonoBehaviour
{
    [Header("Bar and Color")]
    [SerializeField, Tooltip("Set the bar you want to effect here, \n please note the bar must be UI and needs to have an image and set to fill")] 
    private Image bar;
    [SerializeField, Tooltip("Used to change the color of the bar set this to determine when the bar should change color the values in the gradient correspond to the position of the bar")] 
    private Gradient gradientColor;
    [Header("Health Script and death")]
    [SerializeField, Tooltip("Health class stores all the health values of this object")]
    private HealthClass health = new HealthClass();
    [SerializeField] private bool death;

    /// <summary> Call this in an if statement to check if
    /// the character has died by running out of health </summary>
    public bool CheckDeath => death;
    
    private void Start() => Setup();

#region Setup and Bar Updates
    /// <summary> Call to reset the
    /// bars and health </summary>
    public void Setup()
    {
        health.Setup();
        bar.fillAmount = 1;
        bar.color = HandleBarColor();
        death = false;
    }
    /// <summary> Updates the color
    /// of the bar  </summary>
    /// <returns>A color value depending on the health of the character</returns>
    private Color HandleBarColor() => gradientColor.Evaluate(InverseLerp(0, health.MaxHealth, health.CurrentHealth));
    /// <summary> will update the bar changing
    /// its color and fill position </summary>
    private void UpdateBar()
    {
        bar.fillAmount = Clamp01(health.CurrentHealth/health.MaxHealth);
        bar.color = HandleBarColor();
    }
#endregion
#region Damaging and Healing
    // Damaging
    
    /// <summary> When called will cause damage to the player by a given interger value</summary>
    /// <param name="_amount">How much to damage the character by</param>
    public void Damage(int _amount)
    {
        health.CurrentHealth -= _amount;
        if(health.CurrentHealth <= 0)
        {
            health.CurrentHealth = 0;
            death = true;
        }
        UpdateBar();
    }
    /// <summary> When called will cause damage to the player by a given float value</summary>
    /// <param name="_amount">How much to damage the character by</param>
    public void Damage(float _amount)
    {
        health.CurrentHealth -= _amount;
        if(health.CurrentHealth <= 0)
        {
            health.CurrentHealth = 0;
            death = true;
        }
        UpdateBar();
    }
    
    // Healing
    
    /// <summary> When called will heal the player by a given interger value</summary>
    /// <param name="_amount">How much to heal the character by</param>
    public void Heal(int _amount)
    {
        health.CurrentHealth += _amount;
        if(health.CurrentHealth >= health.MaxHealth) health.CurrentHealth = health.MaxHealth;
        UpdateBar();
    }
    /// <summary> When called will heal the player by a given float value</summary>
    /// <param name="_amount">How much to heal the character by</param>
    public void Heal(float _amount)
    {
        health.CurrentHealth += _amount;
        if(health.CurrentHealth >= health.MaxHealth) health.CurrentHealth = health.MaxHealth;
        UpdateBar();
    }
#endregion
}
