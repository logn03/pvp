using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroVaCham : MonoBehaviour
{
    public int diem = 0;
    public TextMeshProUGUI diemText;

    public CapNhatMau Mau;
    public float mauHienTai;
    public float mauToiDa = 10;
    public HeroDiChuyen heroDiChuyen;

    public GameObject cinemachineCamera;
    public GameObject gameOverUi;
    public bool isGameOver = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUi.SetActive(false);
        mauHienTai = mauToiDa;
        Mau.CapNhat(mauHienTai, mauToiDa);
        diemText.SetText(diem.ToString());

        // Gọi hàm TimeDown lặp lại mỗi 1 giây
        InvokeRepeating(nameof(TruMauTheoThoiGian), 1f, 1f);
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
                    mauHienTai = 10; // hồi máu về tối đa
                    Mau.CapNhat(mauHienTai, mauToiDa);
                    san.daCham = true; // Đánh dấu đã chạm để không cộng điểm nữa
                    diemText.SetText(diem.ToString());
                }
            }
        }
    }

    private void TruMauTheoThoiGian()
    {
        if (!heroDiChuyen.isGrounded)
        {
            if (mauHienTai > 0)
            {
                mauHienTai -= 2; // trừ 2 máu
                Mau.CapNhat(mauHienTai, mauToiDa);
            }
            else
            {
                // Ngừng gọi TimeDown khi máu = 0
                CancelInvoke(nameof(TruMauTheoThoiGian));
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
        cinemachineCamera.SetActive(false);
        diemText.SetText(diem.ToString());
        Time.timeScale = 0;
    }    

    public void ChoiLai()
    {
        isGameOver = true;
        Time.timeScale = 1;
        diem = 0;
        mauHienTai = mauToiDa;
        Mau.CapNhat(mauHienTai, mauToiDa);
        SceneManager.LoadScene("Game");          
    }    

}
