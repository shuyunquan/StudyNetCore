﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IService
{
    public interface IPDFService
    {
        byte[] CreatePDF(string htmlContent);
    }
}
