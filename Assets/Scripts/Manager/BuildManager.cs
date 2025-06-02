using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers;
    private int selectedTower = 0;
    private Image selectedImage;
    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
        // 현재 선택된 이미지가 없다 > 클릭한 버튼의 이미지 활성화
        // 헌재 선택된 이미지가 있다 > 바꿔라라
    }
    public void SetSelectedImage(Image _selectedImage)
    {
        if (selectedImage != null) selectedImage.gameObject.SetActive(false);
        selectedImage = _selectedImage;
        selectedImage.gameObject.SetActive(true);
    }
}
