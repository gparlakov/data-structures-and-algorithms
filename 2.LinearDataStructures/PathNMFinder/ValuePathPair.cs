using System;
using System.Linq;

namespace PathNMFinder
{
    public class ValuePathPair
    {
        public ValuePathPair(int value, string pathToPrevius = null)
        {
            this.Value = value;
            if (pathToPrevius == null)
            {
                this.PathToHere = value.ToString();
            }
            else
            {
                SavePathToHere(pathToPrevius);
            }
        }
  
        private void SavePathToHere(string pathToPrevius)
        {
            this.PathToHere = string.Format("{0} -> {1} ", pathToPrevius, this.Value.ToString());
        }

        public int Value { get; private set; }
        public string PathToHere { get; private set; }

    }
}
