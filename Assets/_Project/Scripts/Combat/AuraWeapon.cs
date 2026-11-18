using UnityEngine;

public class AuraWeapon : Weapon
{
    protected override bool NeedsTarget => false;
    protected override void Fire()
    {
        foreach( Health enemy in targeter.FindAllTargetsInRange(range))
        {
            enemy.TakeDamage(damage);
        }
        
    }

}
    
