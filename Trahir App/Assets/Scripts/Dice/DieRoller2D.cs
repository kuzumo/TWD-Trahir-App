using System;
using UnityEngine;

public class DieRoller2D : MonoBehaviour
{
    public event Action<int> OnRoll;
    public int Result { get; private set; }
    
    [SerializeField] Vector2 _rollForceMin = new Vector2(0, 350);
    [SerializeField] Vector2 _rollForceMax = new Vector2(0, 450);
    [SerializeField] bool _usePhysics = true;
    [Tooltip("Roll time only applies when not using physics")]
    [SerializeField] float _rollTime = 2f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private static readonly int RollingAnimation = Animator.StringToHash("Rolling");
    private static readonly int[] ResultAnimations = new[]
    {
        Animator.StringToHash("LandOn1"), 
        Animator.StringToHash("LandOn2"),
        Animator.StringToHash("LandOn3"), 
        Animator.StringToHash("LandOn4"),
        Animator.StringToHash("LandOn5"),
        Animator.StringToHash("LandOn6")
    };

    private bool _isRolling;
    private float _timeRemaining;
    private RandomAudioClipPlayer _audioClipPlayer;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true; // Start in kinematic mode
        _animator = GetComponent<Animator>();
        _audioClipPlayer = GetComponent<RandomAudioClipPlayer>();
        
        SetSortingOrder(10); // Set sorting order to ensure the die is in front
    }

    void Update()
    {
        if (!_isRolling) return;
        _timeRemaining -= Time.deltaTime;
        if (_usePhysics || _timeRemaining > 0f) return;
        FinishRolling();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _audioClipPlayer?.PlayRandomClip();
        if (_rigidbody2D.linearVelocity.sqrMagnitude > 10f) return; // Check for sufficient velocity
        FinishRolling();
    }

    public void RollDie(int value = 0)
    {
        // Set the result either randomly or by the given value
        Result = value == 0 ? UnityEngine.Random.Range(1, ResultAnimations.Length + 1) : value;
        if (_usePhysics)
        {
            RollWithPhysics();
        }
        else
        {
            RollWithoutPhysics();
        }
    }

    void RollWithPhysics()
    {
        _rigidbody2D.isKinematic = false; // Switch to non-kinematic to apply physics
        _rigidbody2D.AddForce(GetRollForce()); // Apply force to the die
        _animator.SetTrigger(RollingAnimation); // Trigger the rolling animation
        _isRolling = true; // Set rolling state
    }

    void RollWithoutPhysics()
    {
        _animator.SetTrigger(RollingAnimation); // Trigger the rolling animation
        _isRolling = true; // Set rolling state
        _timeRemaining = _rollTime; // Set the time for the rolling
    }

    void FinishRolling()
    {
        _isRolling = false; // Stop rolling
        _rigidbody2D.isKinematic = true; // Set back to kinematic
        _rigidbody2D.linearVelocity = Vector2.zero; // Stop any movement
        _animator.SetTrigger(ResultAnimations[Result - 1]); // Trigger the animation for the rolled result
        OnRoll?.Invoke(Result); // Invoke the OnRoll event with the result
    }

    Vector2 GetRollForce()
    {
        return new Vector2(
            UnityEngine.Random.Range(_rollForceMin.x, _rollForceMax.x),
            UnityEngine.Random.Range(_rollForceMin.y, _rollForceMax.y));
    }

    void SetSortingOrder(int order)
    {
        // Get the SpriteRenderer component and set the sorting order
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = order; // Set the desired sorting order
        }

        // If using a UI Image instead, set the CanvasRenderer
        var canvasRenderer = GetComponent<CanvasRenderer>();
        if (canvasRenderer != null)
        {
            // Adjust the canvas sorting order if needed
            var canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = order; // Set to a higher sorting order
            }
        }
    }
}
