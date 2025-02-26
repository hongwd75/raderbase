using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarBase.Objects
{
    class DisplayObjectManager
    {
        private int myObjectID = 0;     // 내 객체 id
        private List<BaseObject> objectList = new List<BaseObject>();


        public void Clear()
        {
            myObjectID = 0;
            objectList.Clear();
        }


    }
}
