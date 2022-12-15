using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;                            // Maximum élet
    [SerializeField] float currentHealth = 50f;                         // Jelenlegi élet
    [SerializeField] float lifeBarWidth = 1;                            // Életvonal szélessége
    [SerializeField] Vector3 lifeBarOffset = Vector3.up;                // Életvonal eltolása

    void OnDrawGizmos()
    {
        Vector3 basePos = transform.position + lifeBarOffset;           // Az életcsík középpontjának pozíciója

        Vector3 left = basePos + Vector3.left * lifeBarWidth / 2;       // Az életcsík bal oldalának pozíciója
        Vector3 right = basePos + Vector3.right * lifeBarWidth / 2;     // Az életcsík jobb oldalának pozíciója

        float healthRatio = currentHealth / maxHealth;                  // Az meglévõ élet aránya
        healthRatio = Mathf.Clamp01(healthRatio);                       // A fenti érték 0 és 1 közé korlátozása
        Vector3 turningPoint = left + Vector3.right * lifeBarWidth * healthRatio;
        // Az életcsík itt vált pirosra

        Gizmos.color = Color.green;
        Gizmos.DrawLine(left, turningPoint);                            // Az életcsík zöld része

        Gizmos.color = Color.red;
        Gizmos.DrawLine(turningPoint, right);                           // Az életcsík piros része
    }
}
