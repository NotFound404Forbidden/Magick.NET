﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class EndianReaderTests
    {
        [TestClass]
        public class TheReadDoubleMSBMethod : EndianReaderTests
        {
            [TestMethod]
            public void ShouldReturnNullWhenBufferIsNotLongEnough()
            {
                var reader = new EndianReader(new byte[1] { 0 });

                var result = reader.ReadDoubleMSB();

                Assert.IsNull(result);
            }

            [TestMethod]
            public void ShouldReadDouble()
            {
                var reader = new EndianReader(new byte[8] { 64, 181, 58, 229, 96, 65, 137, 55 });

                var result = reader.ReadDoubleMSB();

                Assert.AreEqual(5434.896, result);
            }

            [TestMethod]
            public void ShouldChangeTheIndex()
            {
                var reader = new EndianReader(new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 });

                reader.ReadDoubleMSB();

                Assert.AreEqual(8U, reader.Index);
            }
        }
    }
}
