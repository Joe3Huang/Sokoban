﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filer
{
    public interface IFiler
    {
        void Save(string filename, IFileable callMeBackforDetails);
        string Load(string filename);
    }
}
