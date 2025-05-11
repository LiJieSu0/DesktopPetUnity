using UnityEngine;

public class DragDeskPetWindow : MonoBehaviour
{
    [SerializeField] private float longPressDuration = 0.5f; // 長按時間閾值（秒）
    [SerializeField] private GameObject deskPetWindow; // 拖曳的桌寵視窗物件
    private Camera mainCamera;
    private bool isLongPressing = false; // 是否進入長按狀態
    private bool isDragging = false; // 是否正在拖曳
    private float pressTime = 0f; // 按下的累計時間
    private Vector2 initialMousePos; // 滑鼠初始位置
    private Vector3 initialWindowPos; // 視窗初始位置

    void Start()
    {
        mainCamera = Camera.main; // 獲取主攝像機
        if (deskPetWindow == null)
        {
            Debug.LogError("DeskPetWindow 未指定！請在 Inspector 中拖放桌寵視窗物件。");
        }
    }

    void Update()
    {
        // 檢測滑鼠左鍵按下
        if (Input.GetMouseButton(0))
        {
            // 將滑鼠位置轉換為世界座標
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // 如果尚未進入拖曳狀態，檢查長按
            if (!isDragging)
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                // 確認是否點擊到此物件的 BoxCollider2D
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (!isLongPressing)
                    {
                        pressTime += Time.deltaTime; // 累計按下時間

                        // 檢查是否達到長按閾值
                        if (pressTime >= longPressDuration)
                        {
                            isLongPressing = true;
                            isDragging = true;
                            initialMousePos = mousePosition;
                            initialWindowPos = deskPetWindow.transform.position; // 記錄視窗初始位置
                        }
                    }
                }
                else
                {
                    // 如果滑鼠移出 BoxCollider2D，且尚未開始拖曳，重置長按
                    ResetPress();
                }
            }

            // 拖曳邏輯
            if (isDragging && deskPetWindow != null)
            {
                Vector2 currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 delta = currentMousePos - initialMousePos; // 計算滑鼠移動距離
                deskPetWindow.transform.position = initialWindowPos + new Vector3(delta.x, delta.y, 0); // 更新視窗位置
            }
        }
        else
        {
            // 滑鼠鬆開時重置狀態
            ResetPress();
        }
    }

    private void ResetPress()
    {
        isLongPressing = false;
        isDragging = false;
        pressTime = 0f;
    }
}