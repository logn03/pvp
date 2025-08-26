using TMPro;
using UnityEngine;

public class HeroVaCham : MonoBehaviour
{
    public int diem = 0;
    public TextMeshProUGUI diemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diemText.SetText(diem.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("san"))
        {
            TinhVaCham san = collision.gameObject.GetComponent<TinhVaCham>();
            if (san != null && !san.daCham)
            {
                // Lấy contact đầu tiên
                ContactPoint2D contact = collision.GetContact(0);
                // Nếu normal hướng lên (va chạm từ trên xuống)
                if (contact.normal.y > 0.9f)
                {
                    diem = diem + 1;

                    san.daCham = true; // Đánh dấu đã chạm để không cộng điểm nữa
                    diemText.SetText(diem.ToString());
                }
            }
        }
    }
}
