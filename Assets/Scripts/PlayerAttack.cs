using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 1.5f;  // Raggio dell'attacco melee
    [SerializeField] private float attackCooldown = 1f; // Tempo di attesa tra gli attacchi
    [SerializeField] private int attackDamage = 10;     // Danno dell'attacco melee
    [SerializeField] private Transform attackOrigin;    // Punto di origine dell'attacco

    private float lastAttackTime;  // Ultimo tempo di attacco

    void Update()
    {
        // Controlla se il giocatore preme il tasto "F" per attaccare
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;  // Registra il tempo dell'ultimo attacco
        }
    }

    private void Attack()
    {
        // Mostra una linea per debug che indica il raggio dell'attacco
        Debug.DrawRay(attackOrigin.position, transform.forward * attackRange, Color.red, 0.5f);

        // Trova tutti gli oggetti nel raggio dell'attacco
        Collider[] hitObjects = Physics.OverlapSphere(attackOrigin.position, attackRange);

        foreach (Collider hitObject in hitObjects)
        {
            // Se l'oggetto ha il componente 'DestroyableObject', chiamalo per distruggerlo
            DestroyableObject destroyableObject = hitObject.GetComponent<DestroyableObject>();

            if (destroyableObject != null)
            {
                // Chiama la funzione per distruggere l'oggetto
                destroyableObject.DestroyObject();
            }
        }
    }
}