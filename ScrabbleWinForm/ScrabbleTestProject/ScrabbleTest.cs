using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrabbleWinForm;

namespace ScrabbleTestProject
{
    [TestClass]
    public class ScrabbleTest
    {
        [TestMethod]
        public void DealTheLetterTest()
        {
            var model = new ScrabbleModel();
            model.DealTheLetters();
            var n = 4;
            for (int i = 0; i < n; i++)
            {
                model.CurrentPlayer.Hand.Remove(model.CurrentLetter);
            }

            if (model.Set.Count == 0)
                Assert.IsTrue(true);

            model.DealTheLetters();
            var expected = 7;
            var actual = model.CurrentPlayer.Hand.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextPlayerTest()
        {
            var model = new ScrabbleModel();
            model.CreatePlayers();
            model.CurrentPlayer = model.Players[1];
            model.NextPlayer();

            var expected = model.Players[0];
            var actual = model.CurrentPlayer;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckEmptyWordTEst()
        {
            var model = new ScrabbleModel();
            var word = "";
            model.CheckWord(word);
        }

        [TestMethod]
        public void FillSetTest()
        {
            var model = new ScrabbleModel();
            var expected = 79;
            var actual = model.Set.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
