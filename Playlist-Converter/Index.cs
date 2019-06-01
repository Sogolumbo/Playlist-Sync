using System;
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

        private List<object> _list;
        public int Number { get; set; }
        public object Node
        {
            get
            {
                return List[Number];
            }
        }
        public List<object> List
        {
            get => _list;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("list");
                }
                else
                {
                    _list = value;
                }
            }
        }

        public override string ToString()
        {
            string TopNodeName;
            if (Node is MusicLibraryItem)
                TopNodeName = (Node as MusicLibraryItem).Name;
            else
                TopNodeName = (Node as PlaylistItem).Name;
            return Number.ToString() + ": " + TopNodeName;
        }
    }
}
