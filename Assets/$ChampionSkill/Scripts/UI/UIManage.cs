namespace View
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class UIManage : MonoBehaviour
    {
        #region Property
        public static UIManage instant { get; private set; }
        public Func<ValueTuple<Status, State.BaseStatus.ImageCharater>> CallBackIconAnsSkills { get; set; }
        public Action<int, float, string> CallBackCountDown { get; set; }
        #endregion

        [HideInInspector] public UICharater uiCharater;
        [HideInInspector] public UIStatus uiStatus;
        void Awake()
        {
            instant = this;

            uiCharater = GetComponent<UICharater>();
            uiStatus = GetComponent<UIStatus>();

            CallBackCountDown = (slot, fillValue, textValue) => uiCharater.SetCountDown(slot, fillValue, textValue);
        }
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            uiCharater.SetHPAndMp(CallBackIconAnsSkills.Invoke().Item1);
            uiCharater.SetIconAndSkills(CallBackIconAnsSkills.Invoke().Item2);
        }
    }
}
