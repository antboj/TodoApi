﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    interface INumber
    {
        void SetNum(int num);
        int GetNum();
    }
}