﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IFileLogger
    {
        void Log(ISeperation separation);
    }
}
