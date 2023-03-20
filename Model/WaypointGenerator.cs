using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace TOS_Helper.Model
{
    /// <summary>
    /// A static class to deal with waypoint generation and saving.
    /// </summary>
    public static class WaypointGenerator
    {
        /// <summary>
        /// This method generates waypoints when called.
        /// </summary>
        /// <param name="waypointName">The name of the waypoint.</param>
        /// <param name="x">The X coordinate of the central banner.</param>
        /// <param name="y">The Y coordinate of the central banner.</param>
        /// <param name="z">The Z coordinate of the central banner.</param>
        /// <param name="width">The width of the banner-grid.</param>
        /// <param name="length">The length of the banner-grid.</param>
        /// <param name="levels">The number of levels to generate.</param>
        /// <param name="radius">The protection range of the banner provide by the block it is placed on.</param>
        /// <param name="orientation">The direction in which the levels spread.</param>
        /// <param name="overworld">Determines whether to generate waypoints in the Overworld.</param>
        /// <param name="nether">Determines whether to generate waypoints in the Nether.</param>
        /// <param name="end">Determines whether to generate waypoints in the End.</param>
        /// <param name="middleEarth">Determines whether to generate waypoints in Middle-Earth.</param>
        /// <param name="utumno">Determines whether to generate waypoints in Utumno.</param>
        /// <returns>An <see cref="ObservableCollection{T}"/> that hold the generated <see cref="Waypoint"/>s.</returns>
        public static ObservableCollection<Waypoint> GenerateWaypoints(string waypointName, double x, double y, double z, double width, double length, double levels, double radius, Defines.ORIENTATION orientation, bool overworld, bool nether, bool end, bool middleEarth, bool utumno)
        {
            // Create the observable collection to hold the waypoints.
            ObservableCollection<Waypoint> waypoints = new ObservableCollection<Waypoint>();

            // Determine the starting X, Y and Z coordinates.
            double startingX = Math.Ceiling(x - (width - 1) * radius / 2);
            double startingZ = Math.Ceiling(z - (length - 1) * radius / 2);
            double startingY = y;

            // Figure out from which Y level to start.
            switch (orientation)
            {
                case Defines.ORIENTATION.BOTTOM: startingY = y + radius * levels; break;
                case Defines.ORIENTATION.MIDDLE: startingY = y + radius * Math.Floor(levels / 2); break;
            }
            // Generate the waypoints.
            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < length; j++) 
                {
                    for (int k = 0; k < width; k++)
                    {
                        // Add waypoint to the observable collection.
                        waypoints.Add(new Waypoint(waypointName + k + i + j, (int)(startingX + radius * k), (int)(startingY - radius * i), (int)(startingZ + radius * j), overworld, nether, end, middleEarth, utumno));
                    }
                }
            }
            return waypoints;
        }
        /// <summary>
        /// This methods saves an <see cref="ObservableCollection{T}"/> of <see cref="Waypoint"/>s to
        /// the user computer so they can see the waypoints in-game.
        /// </summary>
        /// <param name="waypoints">The <see cref="Waypoint"/>s to be saved.</param>
        /// <param name="path">The path of the journeymap waypoint folder for the corresponding world.</param>
        public static void SaveToJourneymap(ObservableCollection<Waypoint> waypoints, string path)
        {
            // Iterates over the waypoints, and writes each one into a .json file so Journeymap can display the waypoint.
            foreach (Waypoint waypoint in waypoints)
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                var jsonString = JsonSerializer.Serialize(waypoint, options);
                File.WriteAllText(path + @"\" + waypoint.name + ".json", jsonString);
            }
        }
    }
}
