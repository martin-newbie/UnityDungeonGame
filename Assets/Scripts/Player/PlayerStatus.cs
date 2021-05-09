using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public float maxHp;
    public float maxMp;
    public float maxStress;

    private float curHp;
    private float curMp;
    private float curStress;

    public Text HpText;
    public Slider HpBar;

    public Text MpText;
    public Slider MpBar;

    public Text stressText;
    public Slider stressBar;

    void Start()
    {
        curHp = maxHp;
        curMp = maxMp;
        curStress = 0;
    }

    void Update()
    {
        StatusLogic();
    }

    private void StatusLogic()
    {
        HpText.text = curHp.ToString() + " / " + maxHp.ToString();
        MpText.text = curMp.ToString() + " / " + maxMp.ToString();
        stressText.text = curStress.ToString() + " / " + maxStress.ToString();

        HpBar.value = curHp / maxHp;
        MpBar.value = curMp / maxMp;
        stressBar.value = curStress / maxStress;

        if (curHp > maxHp) curHp = maxHp;
        if (curMp > maxMp) curMp = maxMp;
        if (curStress > maxStress) curStress = maxStress;
        if (curHp < 0) curHp = 0;
        if (curMp < 0) curMp = 0;
        if (curStress < 0) curStress = 0;
    }
}
