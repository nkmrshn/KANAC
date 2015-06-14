using Kansuji;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Kansuji
    {
        [TestMethod]
        public void TestReplaceKansujiToNumerals()
        {
            Assert.AreEqual("あいうえお", "あいうえお".ReplaceKansujiToNumber());

            Assert.AreEqual("0", "〇".ReplaceKansujiToNumber());
            Assert.AreEqual("1", "一".ReplaceKansujiToNumber());
            Assert.AreEqual("2", "二".ReplaceKansujiToNumber());
            Assert.AreEqual("3", "三".ReplaceKansujiToNumber());
            Assert.AreEqual("4", "四".ReplaceKansujiToNumber());
            Assert.AreEqual("5", "五".ReplaceKansujiToNumber());
            Assert.AreEqual("6", "六".ReplaceKansujiToNumber());
            Assert.AreEqual("7", "七".ReplaceKansujiToNumber());
            Assert.AreEqual("8", "八".ReplaceKansujiToNumber());
            Assert.AreEqual("9", "九".ReplaceKansujiToNumber());
            Assert.AreEqual("0", "零".ReplaceKansujiToNumber());

            Assert.AreEqual("10", "十〇".ReplaceKansujiToNumber());
            Assert.AreEqual("11", "十一".ReplaceKansujiToNumber());
            Assert.AreEqual("12", "十二".ReplaceKansujiToNumber());
            Assert.AreEqual("13", "十三".ReplaceKansujiToNumber());
            Assert.AreEqual("14", "十四".ReplaceKansujiToNumber());
            Assert.AreEqual("15", "十五".ReplaceKansujiToNumber());
            Assert.AreEqual("16", "十六".ReplaceKansujiToNumber());
            Assert.AreEqual("17", "十七".ReplaceKansujiToNumber());
            Assert.AreEqual("18", "十八".ReplaceKansujiToNumber());
            Assert.AreEqual("19", "十九".ReplaceKansujiToNumber());

            Assert.AreEqual("101", "百一".ReplaceKansujiToNumber());
            Assert.AreEqual("1001", "千一".ReplaceKansujiToNumber());
            Assert.AreEqual("10001", "一万一".ReplaceKansujiToNumber());

            Assert.AreEqual("001", "〇〇一".ReplaceKansujiToNumber());
            Assert.AreEqual("2001", "二〇〇一".ReplaceKansujiToNumber());
            Assert.AreEqual("794年", "七九四年".ReplaceKansujiToNumber());
            Assert.AreEqual("西暦1600年", "西暦一六〇〇年".ReplaceKansujiToNumber());
            Assert.AreEqual("2015年第15回", "二〇一五年第十五回".ReplaceKansujiToNumber());

            Assert.AreEqual("123056", "壱十弐萬参千伍拾六".ReplaceKansujiToNumber());
            Assert.AreEqual("200020003000300040", "廿京卄兆卅億丗万卌".ReplaceKansujiToNumber());
            Assert.AreEqual("35000000000000000ジンバブエドル", "３京５千兆ジンバブエドル".ReplaceKansujiToNumber());

            Assert.AreEqual("10", "十".ReplaceKansujiToNumber());
            Assert.AreEqual("100", "百".ReplaceKansujiToNumber());
            Assert.AreEqual("1000", "千".ReplaceKansujiToNumber());
            Assert.AreEqual("万", "万".ReplaceKansujiToNumber());
            Assert.AreEqual("億", "億".ReplaceKansujiToNumber());
            Assert.AreEqual("兆", "兆".ReplaceKansujiToNumber());
            Assert.AreEqual("京", "京".ReplaceKansujiToNumber());
            Assert.AreEqual("垓", "垓".ReplaceKansujiToNumber());
            Assert.AreEqual("𥝱", "𥝱".ReplaceKansujiToNumber());
            Assert.AreEqual("穣", "穣".ReplaceKansujiToNumber());
            Assert.AreEqual("溝", "溝".ReplaceKansujiToNumber());
            Assert.AreEqual("澗", "澗".ReplaceKansujiToNumber());
            Assert.AreEqual("正", "正".ReplaceKansujiToNumber());
            Assert.AreEqual("載", "載".ReplaceKansujiToNumber());
            Assert.AreEqual("極", "極".ReplaceKansujiToNumber());
            Assert.AreEqual("恒河沙", "恒河沙".ReplaceKansujiToNumber());
            Assert.AreEqual("阿僧祇", "阿僧祇".ReplaceKansujiToNumber());
            Assert.AreEqual("那由他", "那由他".ReplaceKansujiToNumber());
            Assert.AreEqual("不可思議", "不可思議".ReplaceKansujiToNumber());
            Assert.AreEqual("無量大数", "無量大数".ReplaceKansujiToNumber());

            Assert.AreEqual("10", "一十".ReplaceKansujiToNumber());
            Assert.AreEqual("100", "一百".ReplaceKansujiToNumber());
            Assert.AreEqual("1000", "一千".ReplaceKansujiToNumber());
            Assert.AreEqual("10000", "一万".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000", "一億".ReplaceKansujiToNumber());
            Assert.AreEqual("1000000000000", "一兆".ReplaceKansujiToNumber());
            Assert.AreEqual("10000000000000000", "一京".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000000000000000", "一垓".ReplaceKansujiToNumber());
            Assert.AreEqual("1000000000000000000000000", "一𥝱".ReplaceKansujiToNumber());
            Assert.AreEqual("10000000000000000000000000000", "一穣".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000000000000000000000000000", "一溝".ReplaceKansujiToNumber());
            Assert.AreEqual("1000000000000000000000000000000000000", "一澗".ReplaceKansujiToNumber());
            Assert.AreEqual("10000000000000000000000000000000000000000", "一正".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000000000000000000000000000000000000000", "一載".ReplaceKansujiToNumber());
            Assert.AreEqual("1000000000000000000000000000000000000000000000000", "一極".ReplaceKansujiToNumber());
            Assert.AreEqual("10000000000000000000000000000000000000000000000000000", "一恒河沙".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000000000000000000000000000000000000000000000000000", "一阿僧祇".ReplaceKansujiToNumber());
            Assert.AreEqual("1000000000000000000000000000000000000000000000000000000000000", "一那由他".ReplaceKansujiToNumber());
            Assert.AreEqual("10000000000000000000000000000000000000000000000000000000000000000", "一不可思議".ReplaceKansujiToNumber());
            Assert.AreEqual("100000000000000000000000000000000000000000000000000000000000000000000", "一無量大数".ReplaceKansujiToNumber());

            Assert.AreEqual("999999999999999999999999999999999999999999999999999999999999999999999",
                "九無量大数九千九百九十九不可思議九千九百九十九那由他九千九百九十九阿僧祇九千九百九十九恒河沙九千九百九十九極九千九百九十九載九千九百九十九正九千九百九十九澗九千九百九十九溝九千九百九十九穣九千九百九十九𥝱九千九百九十九垓九千九百九十九京九千九百九十九兆九千九百九十九億九千九百九十九万九千九百九十九"
                .ReplaceKansujiToNumber());

            Assert.AreEqual("あいうえお123456789かきくけこ",
                "あいうえお一億二千三百四十五万六千七百八十九かきくけこ"
                .ReplaceKansujiToNumber());
            Assert.AreEqual("あいうえお123456789かきくけこ123456789",
                "あいうえお一億二千三百四十五万六千七百八十九かきくけこ一億二千三百四十五万六千七百八十九"
                .ReplaceKansujiToNumber());
            Assert.AreEqual("123456789あいうえお123456789かきくけこ",
                "一億二千三百四十五万六千七百八十九あいうえお一億二千三百四十五万六千七百八十九かきくけこ"
                .ReplaceKansujiToNumber());
            Assert.AreEqual("123456789あいうえお123456789かきくけこ123456789",
                "一億二千三百四十五万六千七百八十九あいうえお一億二千三百四十五万六千七百八十九かきくけこ一億二千三百四十五万六千七百八十九"
                .ReplaceKansujiToNumber());
        }

        [TestMethod]
        public void TestReplaceKansujiToWideNumerals()
        {
            Assert.AreEqual("かきくけこ", "かきくけこ".ReplaceKansujiToWideNumber());

            Assert.AreEqual("０", "〇".ReplaceKansujiToWideNumber());
            Assert.AreEqual("１", "一".ReplaceKansujiToWideNumber());
            Assert.AreEqual("２", "二".ReplaceKansujiToWideNumber());
            Assert.AreEqual("３", "三".ReplaceKansujiToWideNumber());
            Assert.AreEqual("４", "四".ReplaceKansujiToWideNumber());
            Assert.AreEqual("５", "五".ReplaceKansujiToWideNumber());
            Assert.AreEqual("６", "六".ReplaceKansujiToWideNumber());
            Assert.AreEqual("７", "七".ReplaceKansujiToWideNumber());
            Assert.AreEqual("８", "八".ReplaceKansujiToWideNumber());
            Assert.AreEqual("９", "九".ReplaceKansujiToWideNumber());
        }

        [TestMethod]
        public void TestReplaceKansujiToNumeralsWithWideOption()
        {
            Assert.AreNotEqual("０", "〇".ReplaceKansujiToNumber());
            Assert.AreNotEqual("１", "一".ReplaceKansujiToNumber());
            Assert.AreNotEqual("２", "二".ReplaceKansujiToNumber());
            Assert.AreNotEqual("３", "三".ReplaceKansujiToNumber());
            Assert.AreNotEqual("４", "四".ReplaceKansujiToNumber());
            Assert.AreNotEqual("５", "五".ReplaceKansujiToNumber());
            Assert.AreNotEqual("６", "六".ReplaceKansujiToNumber());
            Assert.AreNotEqual("７", "七".ReplaceKansujiToNumber());
            Assert.AreNotEqual("８", "八".ReplaceKansujiToNumber());
            Assert.AreNotEqual("９", "九".ReplaceKansujiToNumber());

            Assert.AreEqual("０", "〇".ReplaceKansujiToNumber(true));
            Assert.AreEqual("１", "一".ReplaceKansujiToNumber(true));
            Assert.AreEqual("２", "二".ReplaceKansujiToNumber(true));
            Assert.AreEqual("３", "三".ReplaceKansujiToNumber(true));
            Assert.AreEqual("４", "四".ReplaceKansujiToNumber(true));
            Assert.AreEqual("５", "五".ReplaceKansujiToNumber(true));
            Assert.AreEqual("６", "六".ReplaceKansujiToNumber(true));
            Assert.AreEqual("７", "七".ReplaceKansujiToNumber(true));
            Assert.AreEqual("８", "八".ReplaceKansujiToNumber(true));
            Assert.AreEqual("９", "九".ReplaceKansujiToNumber(true));
        }
    }
}
