using System;
using System.Collections.Generic;

namespace TOS_Helper.Model
{
    /// <summary>
    /// This class defines a waypoint so that it may be converted into .json format.
    /// </summary>
    public class Waypoint
    {
        /// <summary>
        /// The id of the waypoint.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The name of the waypoint.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// The icon of the waypoint to display.
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// The X coordinate of the waypoint.
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// The Y coordinate of the waypoint.
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// The Z coordinate of the waypoint.
        /// </summary>
        public int z { get; set; }
        /// <summary>
        /// The red value of the waypoint's colour.
        /// </summary>
        public int r { get; set; }
        /// <summary>
        /// The green value of the waypoint's colour. 
        /// </summary>
        public int g { get; set; }
        /// <summary>
        /// The blue value of the waypoint's colour.
        /// </summary>
        public int b { get; set; }
        /// <summary>
        /// A <see cref="bool"/> to determine if the waypoint is visible.
        /// </summary>
        public bool enable { get; set; }
        /// <summary>
        /// The type of the waypoint.
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Where the waypoint originated from.
        /// </summary>
        public string origin { get; set; }
        /// <summary>
        /// A <see cref="List{T}"/> of dimension to place the waypoint in.
        /// </summary>
        public List<int> dimensions { get; set; }
        /// <summary>
        /// The constructor to create a <see cref="Waypoint"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="Waypoint"/>.</param>
        /// <param name="x">The X coordinate of the <see cref="Waypoint"/>.</param>
        /// <param name="y">The Y coordinate of the <see cref="Waypoint"/>.</param>
        /// <param name="z">The Z coordinate of the <see cref="Waypoint"/>.</param>
        /// <param name="overworld">A <see cref="bool"/> to determine whether to display wawypoint in the Overworld.</param>
        /// <param name="nether">A <see cref="bool"/> to determine whether to display wawypoint in the Nether.</param>
        /// <param name="end">A <see cref="bool"/> to determine whether to display wawypoint in the End.</param>
        /// <param name="middleEarth">A <see cref="bool"/> to determine whether to display wawypoint in Middle-Earth.</param>
        /// <param name="utumno">A <see cref="bool"/> to determine whether to display wawypoint in Utumno.</param>
        public Waypoint(string name, int x, int y, int z, bool overworld, bool nether, bool end, bool middleEarth, bool utumno)
        {
            // Generate waypoint with appropriate data.
            Random rand = new Random();
            this.id = name;
            this.name = name;
            this.icon = "waypoint-normal.png";
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = rand.Next(255);
            this.g = rand.Next(255);
            this.b = rand.Next(255);
            this.enable = true;
            this.type = "Normal";
            this.origin = "TOSHelper";

            dimensions = new List<int>();
            if (nether)
                this.dimensions.Add(Defines.NETHER_DIMENSION_ID);
            if (overworld)
                this.dimensions.Add(Defines.OVERWORLD_DIMENSION_ID);
            if (end)
                this.dimensions.Add(Defines.END_DIMENSION_ID);
            if (middleEarth)
                this.dimensions.Add(Defines.MIDDLE_EARTH_DIMENSION_ID);
            if (utumno)
                this.dimensions.Add(Defines.UTUMNO_DIMENSION_ID);
        }
    }
}
