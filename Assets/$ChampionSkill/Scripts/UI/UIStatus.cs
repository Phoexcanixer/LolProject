namespace View
{
    using System.Collections.Generic;
    using System.Linq;
    using State.Buff;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIStatus : MonoBehaviour
    {
        public BuffStatus prefabBuff;
        public Transform spawnPointBuff;
        public List<BuffStatus> buffStatuses;

        public BuffStatus CheckBuff(Sprite icon, int stack, string nameBuff)
        {
            BuffStatus _buff;
            if (buffStatuses.Count(item => item.nameBuff.Equals(nameBuff)) > 0)
                _buff = buffStatuses.Where(item => item.nameBuff.Equals(nameBuff)).First().UpdateStack(stack);
            else
                buffStatuses.Add(_buff = Instantiate(prefabBuff, spawnPointBuff).SetBuff(icon, stack, nameBuff));

            return _buff;
        }
        public BuffStatus SelectBuff(string nameBuff) => buffStatuses.Where(item => item.nameBuff.Equals(nameBuff)).First();
        public void DeleteBuff(string nameBuff)
        {
            BuffStatus _buff = buffStatuses.Where(item => item.nameBuff.Equals(nameBuff)).First();
            buffStatuses.Remove(_buff);
            Destroy(_buff.gameObject);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }        
        public void DeleteBuff(BuffStatus buff)
        {
            buffStatuses.Remove(buff);
            Destroy(buff.gameObject);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }
    }
}
