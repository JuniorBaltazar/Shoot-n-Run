using UnityEngine;
using UnityEngine.Events;

public class LifeCharacter : MonoBehaviour {

    [SerializeField] [Range (0, 255)]
    private byte lifeAmount = 0;

    [SerializeField] private UnityEvent deadEvent = null;

    Animator anim;

    private void Awake()
    {
        this.anim = GetComponent<Animator>();
    }

    public void TakeDamage () {
        if (this.lifeAmount <= 0)
            this.deadEvent.Invoke();
        else
            this.lifeAmount--;
    }

    public void SetTriggerAnimation (string nameParameter) {
        if (this.anim)
            this.anim.SetTrigger(nameParameter);
    }
}