using System.Collections.Generic;

namespace Playlist
{
    class Index
    {
        public Index(int number, List<object> list)
        {
            Number = number;
            List = list;
        }
        public int Number { get; set; }
        public object Node
        {
            get
            {
                return List[Number];
            }
        }
        public List<object> List { get; set; }
    }
}
