namespace Common.Cast
{
    using System;
    using System.Collections;
    using UnityEngine;

    public static class ExCaster
    {
        public static void CastSkill(this ICaster victim, float times, Action callBeforCast = null, Action callAfterCast = null, Action<float> callTimeCast = null)
        {
            victim.caster.StartCoroutine(IEDelay());
            IEnumerator IEDelay()
            {
                callBeforCast?.Invoke();
                yield return new WaitWhile(() =>
                {
                    times -= Time.deltaTime * 1;
                    callTimeCast?.Invoke(times);
                    return times >= 0;
                });
                callAfterCast?.Invoke();
            }
        }
    }
}
