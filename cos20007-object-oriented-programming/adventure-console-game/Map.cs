namespace SwinAdventure
{
    public class Map : IdentifiableObject
    {
        private static Map? _instance;
        private List<Path> _paths = new List<Path>();
        private List<Location> _locs = new List<Location>();
        private Map() : base(new string[] { "map" })
        {
            _locs.Add(new Location("default location", "This is the default location"));
        }
        public static Map Instance // singleton design pattern
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Map();
                }
                return _instance;
            }
        }
        public Location DefaultLoc
        {
            get // return the first location added as default location
            {
                return _locs[0];
            }
        }
        public List<Location> Locations
        {
            get { return _locs; }
        }
        public Location? AddLoc(string name, string desc)
        // create and add new loc to map if not exist and return it
        // return null if loc added already
        {
            foreach(Location loc in _locs)
            {
                if(loc.Name == name)
                {
                    return null;
                }
            }
            // create new loc and add to map
            Location newLoc = new Location(name, desc);
            _locs.Add(newLoc);
            return newLoc;
        }
        public string AddLoc(Location loc)
        {
            if (!_locs.Contains(loc))
            {
                _locs.Add(loc);
                return "Successfully add the " + loc.Name + " to the map";
            }
            return "Location already exists in the map"; 
        }
        public Location? Locate(string locName)
        {
            foreach(Location loc in _locs)
            {
                if(loc.Name == locName)
                {
                    return loc;
                }
            }
            return null;
        }
        public string AddPath(string loc1, string loc2, string direction1, string direction2,
            string description1, string description2)
        {
            // check if 2 locs is in locs collection
            // note: Location.Name is case sensitive
            Location? dst1 = _locs.FirstOrDefault(loc => loc.Name == loc1);
            Location? dst2 = _locs.FirstOrDefault(loc => loc.Name == loc2);

            // avoid invalid location
            if(dst1 == null || dst2 == null)
            {
                return "The map does not contains those locations";
            }

            // avoid invalid and inconsistent dirs
            if (!ValidDir(direction1.ToLower(), direction2.ToLower()))
            {
                return "Invalid directions provided";
            }

            // avoid path duplication
            if (PathExist(dst1, dst2))
            {
                return "Already exists a path between " + dst1.Name + " and " + dst2.Name;
            }

            _paths.Add(new Path(dst1, dst2, description1, description2, direction1, direction2));
            return "Successfully create new path between " + dst1.Name + " and " + dst2.Name;
        }
        private bool ValidDir(string strDir1, string strDir2)
        {
            int dirCount = Enum.GetNames(typeof(Direction)).Length;
            int dir1 = -99;
            int dir2 = -99;

            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
            {
                if (dir.ToString() == strDir1)
                {
                    dir1 = (int)dir;
                    continue;
                }
                if (dir.ToString() == strDir2)
                {
                    dir2 = (int)dir;
                }
            }
            // 2 opposite dirs form a sum of (no of dirs - 1) = 9
            if (dir1 + dir2 == dirCount - 1) return true;
            return false;
        }
        private bool PathExist(Location loc1, Location loc2)
        {
            foreach(Path path in _paths)
            {
                if (path.ConnectLocs(loc1, loc2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
