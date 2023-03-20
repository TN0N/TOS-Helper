namespace TOS_Helper.Model
{
    /// <summary>
    /// This class holds the definitions of constant variables.
    /// </summary>
    public static class Defines
    {
        /// <summary>
        /// The protection range offered by a banner placed on a gold block.
        /// </summary>
        public const int GOLD = 65;
        /// <summary>
        /// The protection range offered by a banner placed on a silver block.
        /// </summary>
        public const int SILVER = 33;
        /// <summary>
        /// The protection range offered by a banner placed on a bronze block.
        /// </summary>
        public const int BRONZE = 17;

        /// <summary>
        /// The default language of the application.
        /// </summary>
        public const string DEFAULT_LANGUAGE = "en-US";
        /// <summary>
        /// The default X coordinate of the central banner.
        /// </summary>
        public const int DEFAULT_CENTER_X = 0;
        /// <summary>
        /// The default Y coordinate of the central banner.
        /// </summary>
        public const int DEFAULT_CENTER_Y = 0;
        /// <summary>
        /// The default Z coordinate of the central banner.
        /// </summary>
        public const int DEFAULT_CENTER_Z = 0;
        /// <summary>
        /// The default width of the banner-grid.
        /// </summary>
        public const int DEFAULT_WIDTH = 1;
        /// <summary>
        /// The defualt length of the banner-grid.
        /// </summary>
        public const int DEFAULT_LENGTH = 1;
        /// <summary>
        /// The default amount of levels for the banner-grid.
        /// </summary>
        public const int DEFAULT_LEVELS = 1;
        /// <summary>
        /// The default name of the waypoint.
        /// </summary>
        public const string DEFAULT_WAYPOINT_NAME = "";
        /// <summary>
        /// The default path to start the search for the Journeymap waypoint folder.
        /// </summary>
        public const string DEFAULT_JOURNEYMAP_PATH = @"%appdata%\.minecraft";
        /// <summary>
        /// The id of the nether dimension.
        /// </summary>
        public const int NETHER_DIMENSION_ID = -1;
        /// <summary>
        /// The id of the overworld dimension.
        /// </summary>
        public const int OVERWORLD_DIMENSION_ID = 0;
        /// <summary>
        /// The id of the end dimension.
        /// </summary>
        public const int END_DIMENSION_ID = 1;
        /// <summary>
        /// The id of the middle-earth dimension.
        /// </summary>
        public const int MIDDLE_EARTH_DIMENSION_ID = 100;
        /// <summary>
        /// The id of the utumno dimension.
        /// </summary>
        public const int UTUMNO_DIMENSION_ID = 101;
        /// <summary>
        /// An enum to define the possible orientations the banner levels can extend from.
        /// </summary>
        public enum ORIENTATION
        {
            MIDDLE,
            TOP,
            BOTTOM,
        }
    }
}
