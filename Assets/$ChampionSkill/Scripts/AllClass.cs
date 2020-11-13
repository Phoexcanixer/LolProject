public enum ESidePlayer { RedSide, BlueSide, AllEnemy }

#region Interface
public interface ISide
{
    ESidePlayer eSidePlayer { get; }
}
#endregion
