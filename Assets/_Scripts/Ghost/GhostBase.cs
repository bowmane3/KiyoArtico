using UnityEngine;

public class GhostBase : MonoBehaviour
{
    public float maxHP = 3f;

    protected float hp;
    protected Transform player;

    protected virtual void OnEnable()
    {
        GhostManager.ghosts.Add(this);
    }

    protected virtual void OnDisable()
    {
        GhostManager.ghosts.Remove(this);
    }

    protected virtual void Start()
    {
        hp = maxHP;
        player = Camera.main.transform;
    }

    public virtual void TakeDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}