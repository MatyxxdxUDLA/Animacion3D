using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public AnimationClip[] animations;
    private int animationState = 0; // 0 - Idle, 1 - Run, 2 - Dance
    private bool isPaused = false; // Para controlar el estado de pausa

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Cambiar animaciones con las teclas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animationState = (animationState + 1) % animations.Length; // Cambia al siguiente índice
            animator.SetInteger("AnimationState", animationState + 1); // +1 para que empiece desde 1
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animationState = (animationState - 1 + animations.Length) % animations.Length; // Cambia al índice anterior
            animator.SetInteger("AnimationState", animationState + 1); // +1 para que empiece desde 1
        }

        // Pausar la animación con la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                animator.speed = 1;  // Reanudar la animación
                isPaused = false;
            }
            else
            {
                animator.speed = 0;  // Pausar la animación
                isPaused = true;
            }
        }

        // Detener la animación con la tecla S
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("Orc Idle"); // Detener y volver a la animación Idle
            animator.speed = 1; // Asegurarse de que la velocidad esté normal
            isPaused = false; // Asegurarse de que no esté pausada
        }
    }
}
