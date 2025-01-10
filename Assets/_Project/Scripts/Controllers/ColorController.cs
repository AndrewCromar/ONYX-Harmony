using UnityEngine;

public class ColorController : MonoBehaviour
{
    [HideInInspector] public static ColorController Instance;

    [Header("Settings")]
    [SerializeField] private Color[] Colors;
    [SerializeField] private float ColorChangeRate = 4;

    [Header("Debug")]
    [SerializeField] private int CurrentColorIndex = 0;
    [SerializeField] private int NextColorIndex = 0;
    [SerializeField] private float ColorTimer;

    private void Awake() => Instance = this;

    private void Update()
    {
        ColorTimer -= Time.deltaTime;
        if (ColorTimer <= 0)
        {
            ColorTimer = ColorChangeRate;
            int oldColorIndex = CurrentColorIndex;
            while (CurrentColorIndex == oldColorIndex)
            {
                CurrentColorIndex = NextColorIndex;
                NextColorIndex = Random.Range(0, Colors.Length);
            }
        }
    }

    public Color GetColor() => Colors[CurrentColorIndex];
    public Color GetNextColor() => Colors[NextColorIndex];

    public float TimeToNextColor() => ColorTimer;
    public float GetColorChangeRate() => ColorChangeRate;

    public Color[] GetAllColors() => Colors;
}
