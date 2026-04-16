using Matrix2DLib;
namespace Matrix2DTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow(1, 2, 3, 4, "[[1, 2], [3, 4]]")]
        [DataRow(0, 0, 0, 0, "[[0, 0], [0, 0]]")]
        [DataRow(-1, -2, -3, -4, "[[-1, -2], [-3, -4]]")]
        public void Konstructor_DowolneDane_Wydruk(int a, int b, int c, int d, string wydruk)
        {
            // Arrange
            var m = new Matrix2D(a, b, c, d);
            var expected = wydruk;
            // Act
            string actual = m.ToString();
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Property_Zero_Wydruk()
        {
            // Act
            var m = Matrix2D.Zero;
            string expected = "[[0, 0], [0, 0]]";


            // Assert
            Assert.AreEqual("[[0, 0], [0, 0]]", expected);
        }

        [TestMethod]
        public void Equals_M1IM2MajaTakieSameWartosci_ZwracaTrue()
        {
            // Arrange
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(1, 2, 3, 4);

            // Act
            bool result1 = m1.Equals(m2);
            bool result2 = m1.Equals((object)m2);
            bool result3 = m1 == m2;
            bool result4 = m1 != m2;

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void Equals_M1IM2MajaRozneWartosci_ZwracaFalse()
        {
            // Arrange
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(0, 0, 0, 0);

            // Act
            bool result1 = m1.Equals(m2);
            bool result2 = m1.Equals((object)m2);
            bool result3 = m1 == m2;
            bool result4 = m1 != m2;

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod]
        public void Equals_M2JestNull_ZwracaFalse()
        {
            // Arrange
            var m1 = new Matrix2D(1, 2, 3, 4);
            Matrix2D? m2 = null;

            // Act
            bool result1 = m1.Equals(m2);
            bool result2 = m1.Equals((object?)m2);
            bool result3 = m1 == m2;
            bool result4 = m1 != m2;

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod]
        public void GetHashCode_TakieSameWartosci_ZwracaTakiSamHashCode()
        {
            // Arrange
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(1, 2, 3, 4);

                    // Act
                        int hash1 = m1.GetHashCode();
                        int hash2 = m2.GetHashCode();

                        // Assert
                        Assert.AreEqual(hash1, hash2);
                    }

                    [TestMethod]
                    public void OperatorDodawania_DodajeElementy()
                    {
                        var m1 = new Matrix2D(1, 2, 3, 4);
                        var m2 = new Matrix2D(5, 6, 7, 8);
                        var expected = new Matrix2D(6, 8, 10, 12);
                        Assert.AreEqual(expected, m1 + m2);
                    }

                    [TestMethod]
                    public void OperatorOdejmowania_OdejmujeElementy()
                    {
                        var m1 = new Matrix2D(5, 6, 7, 8);
                        var m2 = new Matrix2D(1, 2, 3, 4);
                        var expected = new Matrix2D(4, 4, 4, 4);
                        Assert.AreEqual(expected, m1 - m2);
                    }

                    [TestMethod]
                    public void OperatorMnozenia_MnozyMacierze()
                    {
                        var m1 = new Matrix2D(1, 2, 3, 4);
                        var m2 = new Matrix2D(2, 0, 1, 2);
                        var expected = new Matrix2D(4, 4, 10, 8);
                        Assert.AreEqual(expected, m1 * m2);
                    }

                    [TestMethod]
                    public void OperatorMnozeniaSkalarnego_MnozyElementy()
                    {
                        var m = new Matrix2D(1, 2, 3, 4);
                        var expected = new Matrix2D(3, 6, 9, 12);
                        Assert.AreEqual(expected, m * 3);
                        Assert.AreEqual(expected, 3 * m);
                    }

                    [TestMethod]
                    public void OperatorMinusJednoargumentowy_OdwracaZnakiElementow()
                    {
                        var m = new Matrix2D(1, -2, 3, -4);
                        var expected = new Matrix2D(-1, 2, -3, 4);
                        Assert.AreEqual(expected, -m);
                    }

                    [TestMethod]
                    public void Transpozycja_ZwracaTransponowanaMacierz()
                    {
                        var m = new Matrix2D(1, 2, 3, 4);
                        var expected = new Matrix2D(1, 3, 2, 4);
                        Assert.AreEqual(expected, Matrix2D.Transpose(m));
                        Assert.AreEqual(expected, m.Transpose());
                    }

                    [TestMethod]
                    public void Wyznacznik_ZwracaPoprawnyWyznacznik()
                    {
                        var m = new Matrix2D(1, 2, 3, 4);
                        Assert.AreEqual(-2, Matrix2D.Determinant(m));
                        Assert.AreEqual(-2, m.Det());
                    }

                    [TestMethod]
                    public void JawneRzutowanieNaTabliceInt_ZwracaPoprawnaTablice()
                    {
                        var m = new Matrix2D(1, 2, 3, 4);
                        var array = (int[,])m;
                        Assert.AreEqual(1, array[0, 0]);
                        Assert.AreEqual(2, array[0, 1]);
                        Assert.AreEqual(3, array[1, 0]);
                        Assert.AreEqual(4, array[1, 1]);
                    }

                    [TestMethod]
                    [DataRow("[[1, 2], [3, 4]]", 1, 2, 3, 4)]
                    [DataRow("[1, 2], [3, 4]", 1, 2, 3, 4)]
                    public void Parse_PoprawnyString_ZwracaMacierz(string s, int a, int b, int c, int d)
                    {
                        var expected = new Matrix2D(a, b, c, d);
                        Assert.AreEqual(expected, Matrix2D.Parse(s));
                    }

                            [TestMethod]
                            public void Parse_NiepoprawnyString_ZglaszaWyjatekFormatException()
                            {
                                Assert.Throws<FormatException>(() => Matrix2D.Parse("[[1, 2] [3, 4]]"));
                                Assert.Throws<FormatException>(() => Matrix2D.Parse("invalid"));
                            }
                        }
                    }
