using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HietakissaUtils;
using HietakissaUtils.Health;
using UnityEngine.UI;
using UnityEngine.Animations;


public class CastleManager : MonoBehaviour
{
    public static HealthSystem healthSystem;

    public Image castleHealthImage;
    private void Awake()
    {
        healthSystem = new HealthSystem(500);
        healthSystem.OnHealthChanged += UpdateHealthImage;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthImage()
    {
        castleHealthImage.fillAmount = Maf.PointInRange(healthSystem.GetHealth(), 0, healthSystem.maxHealth);

        print(Maf.PointInRange(healthSystem.GetHealth(), 0, healthSystem.maxHealth));
        print("changed image fillamount");
    }
}
