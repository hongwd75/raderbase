
namespace RadarBase.Objects
{
    class IPoint3D
    {
        public int x;
        public int y;
        public int z;

        public IPoint3D(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public static IPoint3D Zero()
        {
            return new IPoint3D(0, 0, 0);
        }
    }

    class BaseObject
    {
        public eRace race = eRace.Unknown;
        public eRealm realm = eRealm.none;
        public ObjectState State = ObjectState.none;

        public int ObjectID;   // server object id

        public int Health;
        public int Header;
        public int Speed;

        public int zoneID = 0;
        public IPoint3D Position;
        
        public int level = 0;
        public int modelID = 0;
        public string name = "";


        public static BaseObject Create(int objectid)
        {
            return new BaseObject()
            {
                ObjectID = objectid
            };
        }


        public void UpdatePostion(int x,int y,int z)
        {
            Position.x = x;
            Position.y = y;
            Position.z = z;
        }
    }
}
