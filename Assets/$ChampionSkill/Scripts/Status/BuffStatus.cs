namespace State.Buff
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    public class BuffStatus : MonoBehaviour
    {
        [SerializeField] protected Image _iconImg = null, _countDownImg = null;
        [SerializeField] protected TextMeshProUGUI _stackTMP = null;
        public string nameBuff;

        public BuffStatus SetBuff(Sprite icon, int stack, string nameBuff)
        {
            _iconImg.sprite = icon;
            _stackTMP.text = $"{stack}";
            this.nameBuff = nameBuff;
            return this;
        }
        public BuffStatus UpdateStack(int stack)
        {
            _stackTMP.text = $"{stack}";
            return this;
        }

        public void UpdateTImeBuff(float times) => _countDownImg.fillAmount = times;
    }
}
