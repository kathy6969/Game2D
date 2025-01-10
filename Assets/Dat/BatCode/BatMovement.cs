using UnityEngine;

public class BatZigZagMovement : MonoBehaviour
{
    public float horizontalSpeed = 5f;       // Tốc độ di chuyển ngang (trái phải)
    public float zigzagSpeed = 2f;           // Tốc độ của chuyển động zíc zắc
    public float zigzagAmplitude = 2f;       // Biên độ của chuyển động zíc zắc
    public float horizontalRange = 5f;       // Khoảng cách tối đa di chuyển trái phải

    private float startingX;                 // Vị trí X ban đầu

    void Start()
    {
        // Lưu lại vị trí X ban đầu
        startingX = transform.position.x;
    }

    void Update()
    {
        // Tính toán vị trí ngang (trái phải)
        float horizontalMovement = Mathf.PingPong(Time.time * horizontalSpeed, horizontalRange * 2) - horizontalRange;
        float x = startingX + horizontalMovement;

        // Tính toán vị trí zíc zắc lên xuống
        float y = Mathf.Sin(Time.time * zigzagSpeed) * zigzagAmplitude;

        // Cập nhật vị trí của con dơi
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
