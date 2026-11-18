using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class projectWeapon : Weapon
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float bulletVelocity;
    [SerializeField] Transform muzzle;
      
    protected override void Fire()
    {
        if (projectilePrefab == null) return;
       
        Vector3 direction = targeter.TargetPoint - muzzle.position;
        Projectile nProjectile = Instantiate(projectilePrefab, muzzle.position, Quaternion.LookRotation(direction));
       
        nProjectile.Launch(direction.normalized * bulletVelocity, damage);

    }
}
