using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;                            // Maximum �let
    [SerializeField] float currentHealth = 50f;                         // Jelenlegi �let
    [SerializeField] float lifeBarWidth = 1;                            // �letvonal sz�less�ge
    [SerializeField] Vector3 lifeBarOffset = Vector3.up;                // �letvonal eltol�sa

    void OnDrawGizmos()
    {
        Vector3 basePos = transform.position + lifeBarOffset;           // Az �letcs�k k�z�ppontj�nak poz�ci�ja

        Vector3 left = basePos + Vector3.left * lifeBarWidth / 2;       // Az �letcs�k bal oldal�nak poz�ci�ja
        Vector3 right = basePos + Vector3.right * lifeBarWidth / 2;     // Az �letcs�k jobb oldal�nak poz�ci�ja

        float healthRatio = currentHealth / maxHealth;                  // Az megl�v� �let ar�nya
        healthRatio = Mathf.Clamp01(healthRatio);                       // A fenti �rt�k 0 �s 1 k�z� korl�toz�sa
        Vector3 turningPoint = left + Vector3.right * lifeBarWidth * healthRatio;
        // Az �letcs�k itt v�lt pirosra

        Gizmos.color = Color.green;
        Gizmos.DrawLine(left, turningPoint);                            // Az �letcs�k z�ld r�sze

        Gizmos.color = Color.red;
        Gizmos.DrawLine(turningPoint, right);                           // Az �letcs�k piros r�sze
    }
}
