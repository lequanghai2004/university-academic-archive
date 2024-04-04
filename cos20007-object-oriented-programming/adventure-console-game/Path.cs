using SplashKitSDK;
using System.Linq.Expressions;
using System.Timers;

namespace SwinAdventure
{
    public enum Direction
    {
        north=0,
        up=1,
        east=2,
        northwest=3,
        southwest=4,
        northeast=5,
        southeast=6,
        west=7,
        down=8,
        south=9,
    }
    public class Path : IdentifiableObject
    // The identifiers indicate the direction, and can be used to locate the path from the location
    // player from dst1 move dir1 to reach dst2 and receive desc1 mss
    {
        private string[] _description = new string[2];
        private Location[] _dst = new Location[2];
        public Path(Location dst1, Location dst2, string desc1, string desc2, string dir1, string dir2) 
            : base(new string[] { dir1, dir2 })
        { 
            _dst[0] = dst1;
            _dst[1] = dst2;
            _description[0] = desc1;
            _description[1] = desc2;

            dst1.AddPath(dir1, this);
            dst2.AddPath(dir2, this);
        }
        public string FullDescription(int i)
        {
            string dir = (i == 0) ? FirstId() : SecondId();
            return "You head " + dir.Substring(0, 1).ToUpper() + dir.Substring(1)
               + "\n" + _description[i] 
               + "\nYou have arrived in " + _dst[i == 0 ? 1 : 0].Name;
        }
        public Location OtherLoc(Location currentLoc)
        {
            // return the location other than the put in loc
            // return itself if input is not 1 of the locs
            if(currentLoc == _dst[0]) return _dst[1];
            if(currentLoc == _dst[1]) return _dst[0];
            return currentLoc;
        }
        public bool ConnectLocs(Location loc1, Location loc2)
        {
            // return true if this path connects 2 input locations 
            if(_dst.Contains(loc1) && _dst.Contains(loc2)) return true;
            return false;
        }
        public string Travel(Player player)
        {
            Location location = player.Location;
            Location otherLoc = OtherLoc(location);
            // if player loc is not one path endpoint, it returns the input location
            // only move if path returns the other endpoint
            if(!object.ReferenceEquals(location, otherLoc))
            {
                player.Location = otherLoc;
                return FullDescription(Array.IndexOf(_dst, location));
            }
            return "Cannot use this path";
        }
    }
}

