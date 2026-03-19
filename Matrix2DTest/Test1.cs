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
        public void Equals_M1AndM2HaveSameValues_ReturnsTrue()
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
        public void Equals_M1AndM2HaveDifferentValues_ReturnsFalse()
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
        public void Equals_M2IsNull_ReturnsFalse()
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
        public void GetHashCode_SameValues_ReturnsSameHashCode()
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
    }
}
