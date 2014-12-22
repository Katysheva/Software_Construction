using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrabbleWinForm;
using System.Collections.Generic;

namespace ScrabbleTestProject
{
    [TestClass]
    public class ScrabbleTest
    {
        [TestMethod]
        public void DealTheLetterTest()
        {
            var model = new ScrabbleModel();
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
        [TestMethod]
        public void ScoreTest()
        {
            var model = new ScrabbleModel();
            var wordLetters = new List<Letter>() 
            {
                new Letter('А', 1),
                new Letter('Р', 2),
                new Letter('Б', 3),
                new Letter('У', 2),
                new Letter('З', 5),
            };
            for (int i = 0; i < 5; i++)
            {
                model.AddToCell(model.Grid[8 + i, 8], wordLetters[i]);
            }
            model.WordAssembly();
            model.ScoreCount();
            var expected = 19;
            var actual = model.CurrentPlayer.Score;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckWordTest()
        {
            var model = new ScrabbleModel();
            var str = "ПиНгвин";
            var actual = model.CheckWord(str);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void WordAssemblyTest()
        {
            var model = new ScrabbleModel();
            model.Grid[7, 8] = new BusyCell(new Letter('А', 1));
            var wordLetters = new List<Letter>() 
            {
                new Letter('Р', 2),
                new Letter('Б', 3),
                new Letter('У', 2),
                new Letter('З', 5),
            };
            for (int i = 0; i < wordLetters.Count; i++)
            {
                model.AddToCell(model.Grid[8 + i, 8], wordLetters[i]);
            }
            var actual = model.WordAssembly();
            var expected = "АРБУЗ";
            Assert.AreEqual(expected, actual);
        }

    }
}
