public static class Constants
{

    #region Card 
    public const string CARD_PICK_UP_LAYER = "PickedUpCard";
    public const string DEFAULT_LAYER = "Default";
    public const string CARD_TAG = "Card";
    public const string MOVEMENT_PLANE_TAG = "MovementPlane";
    #endregion

    #region Screen
    public const int WINDOW_WIDTH = 1920;
    public const int WINDOW_HEIGHT = 1080;
    public const bool START_IN_FULLSCREEN = false;
    public const float TARGET_ASPECT_RATIO = 16f / 9f;
    #endregion

    //FIXME: These probably shouldn't be constants. However we may want some constants related to graphics
    #region Graphics
    public const int TEXTURE_WIDTH = 3840;
    public const int TEXTURE_HEIGHT = 2160;
    #endregion
}
