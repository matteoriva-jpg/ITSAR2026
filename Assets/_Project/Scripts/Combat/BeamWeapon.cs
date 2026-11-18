using UnityEditor.Experimental.GraphView;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class BeamWeapon : Weapon
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform muzzle;
    [SerializeField] Color startColor = Color.red;
    [SerializeField] Color endColor = Color.purple;
    [SerializeField] float LineThickness = .25f;

    protected override void Awake()
    {
        base.Awake();
        if (lineRenderer) lineRenderer = GetComponentInParent<LineRenderer>();
        
       

    }

    protected override void Fire()
    {
        targeter?.CurrentTarget.TakeDamage(damage);

    }

    protected override void Update()
    {
        base.Update();
        if (lineRenderer)
        {
            if (targeter && targeter.CurrentTarget != null)
            {


                Vector3 lineStart = muzzle.position;
                Vector3 lineEnd = targeter.TargetPoint;

                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, lineStart);
                lineRenderer.SetPosition(1, lineEnd);

                lineRenderer.startColor = startColor;
                lineRenderer.endColor = endColor;
                lineRenderer.startWidth = LineThickness;
                lineRenderer.endWidth = LineThickness;
            }

            else
            {
                lineRenderer.positionCount = 0;
                lineRenderer.startColor = new Color(0, 0, 0, 0);
                lineRenderer.endColor = new Color(0, 0, 0, 0);

            }
        }
    }
        
   
}

