﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetrieveBitmap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveBitmap.Tests
{
    [TestClass()]
    public class RetrieveTests
    {
        [TestMethod()]
        public void GetBitMapTest()
        {
            if (Retrieve.GetBitMap("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png", out Bitmap bitmap))
                Assert.IsNotNull(bitmap);
        }
    }
}