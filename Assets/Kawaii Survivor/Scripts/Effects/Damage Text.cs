using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshPro damageText;

    [NaughtyAttributes.Button]
    public void Animate(int damage)//string damage, bool isCriticalHit
    {
        damageText.text = damage.ToString();
        animator.Play("Animate");

        //damageText.color = isCriticalHit ? Color.yellow : Color.white;
    }
}
