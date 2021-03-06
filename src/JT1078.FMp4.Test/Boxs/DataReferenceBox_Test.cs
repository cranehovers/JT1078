﻿using JT1078.FMp4.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT1078.Protocol.Extensions;
using JT1078.FMp4.Enums;

namespace JT1078.FMp4.Test.Boxs
{
    public class DataReferenceBox_Test
    {
        /// <summary>
        /// 使用doc/video/demo.mp4
        /// </summary>
        [Fact]
        public void Test1()
        {
//              00 00 00 1c--box size 28
//              64 72 65 66--box type dref
//              00--version
//              00 00 00--flags
//              00 00 00 01--entry_count
//----------------
//                00 00 00 0c--box size 12
//                75 72 6c 20--box type "url " 有个空格
//                00--version
//                00 00 01--flags
            DataReferenceBox dataReferenceBox = new DataReferenceBox();
            dataReferenceBox.DataEntryBoxes.Add(new DataEntryUrlBox(version:0,flags:1));
            FMp4MessagePackWriter writer = new MessagePack.FMp4MessagePackWriter(new byte[48]);
            dataReferenceBox.ToBuffer(ref writer);
            var hex = writer.FlushAndGetArray().ToHexString();
            Assert.Equal("0000001c6472656600000000000000010000000c75726c2000000001".ToUpper(), hex);
        }
    }
}
