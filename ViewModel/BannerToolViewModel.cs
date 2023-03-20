using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using TOS_Helper.Model;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TOS_Helper.ViewModel
{
    /// <summary>
    /// This class is the viewmodel that binds BannerHelper view with the <see cref="WaypointGenerator"/> model.
    /// </summary>
    public class BannerToolViewModel : BindableBase
    {
        private string _waypointName;
        private int _centerX;
        private int _centerZ;
        private int _centerY;
        private int _protectionRadius;
        private int _width;
        private int _length;
        private int _levels;
        private string _journeymapPath;
        private Defines.ORIENTATION _orientation;
        private ObservableCollection<Waypoint> _waypoints = new ObservableCollection<Waypoint>();
        private bool _overworldSelected;
        private bool _netherSelected;
        private bool _endSelected;
        private bool _middleEarthSelected;
        private bool _utumnoSelected;

        /// <summary>
        /// Determines if the Overworld is selected in the view.
        /// </summary>
        public bool OverworldSelected
        {
            get => _overworldSelected;
            set
            {
                SetProperty(ref _overworldSelected, value);
                GenerateWaypoints.RaiseCanExecuteChanged();
                SaveJourneymap.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// Determines if the Nether is selected in the view.
        /// </summary>
        public bool NetherSelected
        {
            get => _netherSelected;
            set
            {
                SetProperty(ref _netherSelected, value);
                GenerateWaypoints.RaiseCanExecuteChanged();
                SaveJourneymap.RaiseCanExecuteChanged();
            }

        }
        /// <summary>
        /// Determines if the End is selected in the view.
        /// </summary>
        public bool EndSelected
        {
            get => _endSelected;
            set
            {
                SetProperty(ref _endSelected, value);
                GenerateWaypoints.RaiseCanExecuteChanged();
                SaveJourneymap.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// Determines if Middle-Earth is selected in the view.
        /// </summary>
        public bool MiddleEarthSelected
        {
            get => _middleEarthSelected;
            set
            {
                SetProperty(ref _middleEarthSelected, value);
                GenerateWaypoints.RaiseCanExecuteChanged();
                SaveJourneymap.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// Determines if Utumno is selected in the view.
        /// </summary>
        public bool UtumnoSelected
        {
            get => _utumnoSelected;
            set
            {
                SetProperty(ref _utumnoSelected, value);
                GenerateWaypoints.RaiseCanExecuteChanged();
                SaveJourneymap.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// Determines if the gold block is selected.
        /// </summary>
        public bool IsGoldProtected 
        { 
            get => _protectionRadius == Defines.GOLD;
        }
        /// <summary>
        /// Determines if the silver block is selected.
        /// </summary>
        public bool IsSilverProtected
        {
            get => _protectionRadius == Defines.SILVER;
        }
        /// <summary>
        /// Determines if the bronze block is selected.
        /// </summary>
        public bool IsBronzeProtected
        {
            get => _protectionRadius == Defines.BRONZE;
        }
        /// <summary>
        /// Determines if the top orientation is selected.
        /// </summary>
        public bool IsTopOriented
        {
            get => _orientation == Defines.ORIENTATION.TOP;
        }
        /// <summary>
        /// Determines if the middle orientation is selected.
        /// </summary>
        public bool IsMiddleOriented
        {
            get => _orientation == Defines.ORIENTATION.MIDDLE;
        }
        /// <summary>
        /// Determines if the bottom orientation is selected.
        /// </summary>
        public bool IsBottomOriented
        {
            get => _orientation == Defines.ORIENTATION.BOTTOM;
        }
        /// <summary>
        /// The waypoint name.
        /// </summary>
        public string WaypointName
        {
            get => _waypointName;
            set
            {
                SetProperty(ref _waypointName, value);
                Settings.Default.waypoint_name = this._waypointName;
            }
        }
        /// <summary>
        /// The x coordinate of the banner.
        /// </summary>
        public int CenterX
        {
            get => _centerX;
            set
            {
                SetProperty(ref _centerX, value);
                Settings.Default.x = this._centerX;
            }
        }
        /// <summary>
        /// The z coordinate of the banner.
        /// </summary>
        public int CenterZ
        {
            get => _centerZ;
            set
            {
                SetProperty(ref _centerZ, value);
                Settings.Default.z = this._centerZ;
            }
        }
        /// <summary>
        /// The y coordinate of the banner.
        /// </summary>
        public int CenterY
        {
            get => _centerY;
            set
            {
                SetProperty(ref _centerY, value);
                Settings.Default.y = this._centerY;
            }
        }
        /// <summary>
        /// The radius of the banner's protection.
        /// </summary>
        public int ProtectionRadius 
        {
            get => _protectionRadius;
            set
            {
                SetProperty(ref _protectionRadius, value);
                Settings.Default.protection_radius = this._protectionRadius;
            }
        }
        /// <summary>
        /// The banner grid width.
        /// </summary>
        public int Width
        { 
            get => _width;
            set
            {
                SetProperty(ref _width, value);
                Settings.Default.size = this._width;
            }
        }
        /// <summary>
        /// The banner grid length.
        /// </summary>
        public int Length
        {
            get => _length;
            set
            {
                SetProperty(ref _length, value);
                Settings.Default.size = this._length;
            }
        }
        /// <summary>
        /// The number of levels to protect.
        /// </summary>
        public int Levels
        {
            get => _levels;
            set
            { 
                SetProperty(ref _levels, value);
                Settings.Default.levels = this._levels;
            }
        }
        /// <summary>
        /// The path to the journeymap waypoint folder.
        /// </summary>
        public string JourneymapPath
        {
            get => _journeymapPath;
            set
            {
                SetProperty(ref _journeymapPath, value);
                Settings.Default.journeymap_path = this._journeymapPath;
            }
        }
        /// <summary>
        /// The "orientation of the protaction"
        /// </summary>
        public Defines.ORIENTATION Orientation
        {
            get => _orientation;
            set
            {
                SetProperty(ref _orientation, value);
                Settings.Default.orientation = (int)this._orientation;
            }
        }
        /// <summary>
        /// The generated waypoints.
        /// </summary>
        public ObservableCollection<Waypoint> Waypoints
        {
            get => _waypoints;
            set => SetProperty(ref _waypoints, value);
        }
        /// <summary>
        /// Command that generates the waypoints.
        /// </summary>
        public DelegateCommand GenerateWaypoints
        {
            get;
            private set;
        }
        /// <summary>
        /// Command that saves the waypoints to the journeymap waypoints folder.
        /// </summary>
        public DelegateCommand SaveJourneymap
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets protection radius to gold.
        /// </summary>
        public DelegateCommand SetProtectionGold
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets protection radius to silver.
        /// </summary>
        public DelegateCommand SetProtectionSilver
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets protection radius to bronze.
        /// </summary>
        public DelegateCommand SetProtectionBronze
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets the orientation to top down.
        /// </summary>
        public DelegateCommand SetOrientationTop
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets orientation to middle.
        /// </summary>
        public DelegateCommand SetOrientationMiddle
        {
            get;
            private set;
        }
        /// <summary>
        /// Sets orientation to bottom up.
        public DelegateCommand SetOrientationBottom
        {
            get;
            private set;
        }
        private void CommandGenerateWaypoints()
        {
            this.Waypoints = WaypointGenerator.GenerateWaypoints(_waypointName, _centerX, _centerY, _centerZ, _width, _length, _levels, _protectionRadius, _orientation, _overworldSelected, _netherSelected, _endSelected, _middleEarthSelected, _endSelected);
        }
        private bool CanGenerateWaypoints() => OverworldSelected || NetherSelected || EndSelected || MiddleEarthSelected || UtumnoSelected;

        private void CommandSaveJourneymap()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            dialog.DefaultDirectory = ConfigurationManager.AppSettings.Get(Settings.Default.journeymap_path);

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) 
            {
                JourneymapPath = dialog.FileName;
                WaypointGenerator.SaveToJourneymap(_waypoints, _journeymapPath);
            }
        }
        private void CommandSetProtectionGold()
        {
            ProtectionRadius = Defines.GOLD;
        }
        private void CommandSetProtectionSilver()
        {
            ProtectionRadius = Defines.SILVER;
        }
        private void CommandSetProtectionBronze()
        {
            ProtectionRadius = Defines.BRONZE;
        }
        private void CommandSetOrientationTop()
        {
            Orientation = Defines.ORIENTATION.TOP;
        }
        private void CommandSetOrientationMiddle()
        {
            Orientation = Defines.ORIENTATION.MIDDLE;
        }
        private void CommandSetOrientationBottom()
        {
            Orientation = Defines.ORIENTATION.BOTTOM;
        }

        public BannerToolViewModel()
        {
            
            // Load defaults
            _centerX = Defines.DEFAULT_CENTER_X;
            _centerZ = Defines.DEFAULT_CENTER_Z;
            _centerY = Defines.DEFAULT_CENTER_Y;
            _width = Defines.DEFAULT_WIDTH;
            _length = Defines.DEFAULT_LENGTH;
            _levels = Defines.DEFAULT_LEVELS;
            _waypointName = Defines.DEFAULT_WAYPOINT_NAME;
            _journeymapPath = Settings.Default.journeymap_path;
            _protectionRadius = Defines.GOLD;
            _orientation = (Defines.ORIENTATION)Settings.Default.orientation;
            _middleEarthSelected = true;

            GenerateWaypoints = new DelegateCommand(CommandGenerateWaypoints, CanGenerateWaypoints);
            SaveJourneymap = new DelegateCommand(CommandSaveJourneymap, CanGenerateWaypoints);
            SetProtectionGold = new DelegateCommand(CommandSetProtectionGold);
            SetProtectionSilver = new DelegateCommand(CommandSetProtectionSilver);
            SetProtectionBronze = new DelegateCommand(CommandSetProtectionBronze);
            SetOrientationTop = new DelegateCommand(CommandSetOrientationTop);
            SetOrientationMiddle = new DelegateCommand(CommandSetOrientationMiddle);
            SetOrientationBottom = new DelegateCommand(CommandSetOrientationBottom);
        }
    }
}
