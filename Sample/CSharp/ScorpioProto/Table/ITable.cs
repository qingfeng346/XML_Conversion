﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScorpioProto.Table {
    public interface ITable {
        IData GetValueObject(object key);
        bool ContainsObject(object ID);
        IDictionary GetDatas();
        int Count();
    }
}
