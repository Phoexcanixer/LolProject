namespace View
{
    using System.Collections;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UICharater : MonoBehaviour
    {
        [System.Serializable]
        public struct CountDownSkill
        {
            public Image countDownImg;
            public Text countDownTxt;
        }

        public Image IconImg;
        public Image wardImg, recallImg;
        public Slider hpSld, mpSld;
        public Text hpTxt, mpTxt;
        public GameObject gateCastBar;
        public Slider castSld;
        public TextMeshProUGUI nameSkillCastTMP;

        public Image[] allSkillImgs;
        public Image[] allSpellImgs;
        public Image[] allItemImgs;
        public CountDownSkill[] countDownSkills;

        void Awake()
        {
            hpSld.onValueChanged.AddListener(f => hpTxt.text = $"{f:#} / {hpSld.maxValue:#}");
            mpSld.onValueChanged.AddListener(f => mpTxt.text = $"{f:#} / {mpSld.maxValue:#}");
        }
        // SetStart //
        public void SetIconAndSkills(State.BaseStatus.ImageCharater imageCharater)
        {
            IconImg.sprite = imageCharater.iconCharater;
            for (int i = 0; i < allSkillImgs.Length; i++)
            {
                allSkillImgs[i].sprite = imageCharater.allSkills[i];
            }
        }
        public void SetHPAndMp(Status status)
        {
            hpSld.maxValue = status.hp;
            mpSld.maxValue = status.mp;

            hpSld.value = hpSld.maxValue;
            mpSld.value = mpSld.maxValue;

            hpTxt.text = $"{status.hp:#} / {status.hp:#}";
            mpTxt.text = $"{status.mp:#} / {status.mp:#}";
        }
        // Set When Call //
        public void SetCountDown(int slot, float fillValue, string textValue)
        {
            countDownSkills[slot].countDownImg.fillAmount = fillValue;
            countDownSkills[slot].countDownTxt.gameObject.SetActive(true);

            if (fillValue > 0)
                countDownSkills[slot].countDownTxt.text = textValue;
            else
                countDownSkills[slot].countDownTxt.gameObject.SetActive(false);
        }
        public void SetCastSkill(float timeCast, string nameSkill,float mpRemain)
        {
            gateCastBar.SetActive(true);
            nameSkillCastTMP.text = nameSkill;
            castSld.minValue = -timeCast;
            castSld.maxValue = 0;
            castSld.value = castSld.minValue;
            mpSld.value = mpRemain;
        }
        public void SetCountCastSkill(float timeCast)
        {
            castSld.value = -timeCast;
            if (castSld.value >= castSld.maxValue)
                gateCastBar.SetActive(false);
        }
    }
}
