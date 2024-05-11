using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    // Tenging við TextMeshProUGUI til að birta stigin
    public TextMeshProUGUI stigText;

    void Start()
    {
        // Sækja gildið stig úr PlayerPrefs
        int stigValue = PlayerPrefs.GetInt("Stig", 0);

        // Uppfæra texta TextMeshProUGUI hlutsins
        stigText.text = "þu varst með " + stigValue.ToString()+" stig";
    }
}
