using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Phones
{
    public class PhoneRecords
    {
        private const char SeparatorField =  '|' ;
        private const char SeparatorNames = ' ';

        MultiDictionary<string, PhoneRecord> recordsByName;
        MultiDictionary<string, PhoneRecord> recordsByTown;

        public PhoneRecords()
        {
            this.recordsByName = new MultiDictionary<string, PhoneRecord>(true);
            this.recordsByTown = new MultiDictionary<string, PhoneRecord>(true);
        }

        public void Add(PhoneRecord record)
        {
            string[] nameTownNumber = record.Record.Split(new char[] { SeparatorField }, StringSplitOptions.RemoveEmptyEntries);
            this.recordsByTown.Add(nameTownNumber[1].Trim(), record);

            string[] firstMiddleLastNickName = nameTownNumber[0].Split(new char[] { SeparatorNames }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < firstMiddleLastNickName.Length; i++)
            {
                this.recordsByName.Add(firstMiddleLastNickName[i].Trim(), record);
            }
        }

        public IEnumerable<PhoneRecord> Find(string nameOrNick)
        { 
            var foundRecords = FindByIn(nameOrNick, recordsByName);

            return foundRecords;
        }  

        public IEnumerable<PhoneRecord> Find(string nameOrNick, string town)
        {
            var foundByName = FindByIn(nameOrNick, recordsByName);
            var foundByTown = FindByIn(town, recordsByTown);

            var intersect = foundByName.Intersect<PhoneRecord>(foundByTown);

            return intersect;
        }

        private List<PhoneRecord> FindByIn(string searchStr, MultiDictionary<string, PhoneRecord> recordsDictionary)
        {
            var found = recordsDictionary.FindAll(x => x.Key == searchStr);
            var foundRecords = new List<PhoneRecord>();

            foreach (var item in found)
            {
                foundRecords.AddRange(item.Value.ToArray<PhoneRecord>());
            }

            return foundRecords;
        }
    }
}
