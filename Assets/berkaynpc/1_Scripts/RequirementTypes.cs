using UnityEngine;

public class RequirementTypes : MonoBehaviour
{
    // [Flags]  //�uan �al��m�yor �are bulunca eklenecek. e�le�tirme red,blue ar�yor. ayr� ayr� g�rm�yor split ile belki ��z�lebilir

    #region Global Req Types
    [SerializeField] RequirementType reqType;
    public enum RequirementType
    {
        nothing,
        RedKey,
        BlueKey,
        GreenKey,
        Battery,
        Wire,
        CubeNothing,
        CubeRed,
        CubeGreen,
        CubeBlue,
        //daha fazla �ey eklenebilir
    }

    public RequirementType GetKeyType()
    {
        return reqType;
    }
    #endregion

    #region Laser Types

    [SerializeField] LaserReqTypes laserReqType;
    public enum LaserReqTypes
    {
        nothing,
        RedLaser,
        BlueLaser,
        GreenLaser,
    }
    public LaserReqTypes GetLaserReqType()
    {
        return laserReqType;
    }

    #endregion

    #region Spell Element Types

    [SerializeField] SpellElementTypes spellElementType;
    public enum SpellElementTypes
    {
        Electricity,
        Fire,
        Ice,
        Wind,
        Light,
    }
    public SpellElementTypes GetElementType()
    {
        return spellElementType;
    }

    #endregion
}


