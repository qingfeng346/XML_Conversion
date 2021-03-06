
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ScorpioProto.Commons;
using ScorpioProto.Table;

namespace scov {
public partial class TableSpawn : ITable {
	const string FILE_MD5_CODE = "484cdae7d179982f1c7868078204d81d";
    private int m_count = 0;
    private Dictionary<int, DataSpawn> m_dataArray = new Dictionary<int, DataSpawn>();
    public TableSpawn Initialize(string fileName, IScorpioReader reader) {
        var iRow = TableUtil.ReadHead(reader, fileName, FILE_MD5_CODE);
        for (var i = 0; i < iRow; ++i) {
            var pData = DataSpawn.Read(fileName, reader);
            if (m_dataArray.ContainsKey(pData.ID())) {
                m_dataArray[pData.ID()].Set(pData);
            } else {
                m_dataArray.Add(pData.ID(), pData);
            }
        }
        m_count = m_dataArray.Count;
        return this;
    }
    public DataSpawn GetValue(int ID) {
        if (m_dataArray.ContainsKey(ID)) return m_dataArray[ID];
        TableUtil.Warning("DataSpawn key is not exist " + ID);
        return null;
    }
    public bool Contains(int ID) {
        return m_dataArray.ContainsKey(ID);
    }
    public Dictionary<int, DataSpawn> Datas() {
        return m_dataArray;
    }
    
    public IData GetValueObject(object ID) {
        return GetValue((int)ID);
    }
    public bool ContainsObject(object ID) {
        return Contains((int)ID);
    }
    public IDictionary GetDatas() {
        return Datas();
    }
    public int Count() {
        return m_count;
    }
}

}