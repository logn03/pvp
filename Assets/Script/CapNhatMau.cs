using UnityEngine;
using UnityEngine.UI;

public class CapNhatMau : MonoBehaviour
{
    public Image ThanhMau;

    public void CapNhat(float mauHienTai, float mauToiDa)
    {
        ThanhMau.fillAmount = mauHienTai / mauToiDa;
    }
}
